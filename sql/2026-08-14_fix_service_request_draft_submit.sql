/* ============================================================================
   แก้ปัญหา : พนักงานกดส่งใบ Draft ที่ HR สร้างแทน แล้วไม่ขึ้น dialog ไม่ redirect

   ต้องรัน 2026-08-11_add_service_draft_onbehalf.sql
   และ 2026-08-12_add_service_createmode.sql ก่อน

   ------------------------------------------------------------------------------
   อาการที่ผู้ใช้เจอ
     กรอกข้อมูลในหน้า FormUpdate เสร็จ กดส่ง แล้วไม่มีอะไรเกิดขึ้น
     ไม่มีข้อความสำเร็จ ไม่มี error ค้างอยู่หน้าเดิม

   สาเหตุ  ฝั่งหน้าจอมีด่านนี้
       var serviceNo = await $scope.ServiceRequest();
       if (serviceNo) { alertSuccess(...); location.href = '/Service/Index'; }

     ถ้า proc ไม่คืน serviceNo ออกมา จะไม่เข้าเงื่อนไข จึงเงียบสนิท

   มีจุดผิด 2 จุด
     [1] up_service_request_upd_resend  (ตัวที่หน้า FormUpdate เรียก)
         อ่านเลขที่เดิมมาคืน ไม่ได้สร้างใหม่
         ใบ Draft ยังไม่มีเลขที่ จึงคืน NULL  <- ต้นเหตุตรงของอาการ

     [2] up_service_request_upd  (เส้นทางส่งปกติ)
         ด่านตรวจสิทธิ์ใช้ createBy = @userBy
         ใบที่ HR สร้างแทนมี createBy = HR ส่วนคนกดส่งคือพนักงาน
         count จึงเป็น 0 แล้วโดน raiserror ส่งไม่ได้เลย
   ============================================================================ */

USE [EmpHub]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* ============================================================================
   [1] up_service_request_upd_resend  :  ออกเลขที่ให้เมื่อยังไม่มี

   ใบที่มีเลขที่แล้ว  -> ใช้เลขเดิม พฤติกรรมเหมือนของเดิมทุกอย่าง
   ใบที่ยังไม่มีเลข   -> ออกเลขใหม่ด้วยสูตรเดียวกับ up_service_request_upd

   ครอบ while loop ไว้เหมือนตัวเดิม เพราะการออกเลขแบบ max()+1
   ชนกันได้ถ้ามีคนกดส่งพร้อมกัน  ถ้าชนแล้วให้วนหาเลขใหม่

   *** ข้อความ raiserror ***
   ไฟล์ต้นฉบับที่ส่งมาเป็น UTF-16 ตอนอ่านข้อความไทยกลายเป็นอักขระเพี้ยน
   ผมจึงเขียนข้อความใหม่ให้ ถ้าต้องการถ้อยคำเดิมให้แก้บรรทัด raiserror
   กลับเป็นของเดิมหลังรัน
   ============================================================================ */
ALTER procedure [dbo].[up_service_request_upd_resend]
(
@id nvarchar(50)
, @userBy nvarchar(50)
, @serviceNo nvarchar(50) output
)
as
begin

	/* check step generate */
	if(select count(*) from ServiceStepInfo t with(nolock)
	where t.is_active = 1
	and t.refId = @id) = 0
	begin

		exec up_service_step_ins @id, @userBy

	end


	declare @status nvarchar(50) = dbo.fn_service_next_status(@id)

	if isnull(@status,'') != ''
	begin

		select top 1 @serviceNo = t.serviceNo
		from ServiceInfo t with(nolock)
		where t.is_active = 1
		and t.id = @id

		/* ---- เพิ่ม : ใบที่ยังไม่มีเลขที่ ให้ออกเลขให้ ----
		   เกิดกับใบที่ HR สร้างแทนไว้ให้พนักงานกรอก เพราะ up_service_ins
		   ไม่ได้ insert serviceNo  ถ้าไม่ออกเลขให้ที่นี่ proc จะคืน NULL
		   แล้วหน้าจอจะไม่ขึ้นข้อความสำเร็จและไม่ redirect */
		if isnull(@serviceNo,'') = ''
		begin

			declare @format nvarchar(50)
			, @maxId int
			, @round int = 1
			, @flag int = 0

			set @format = 'HRS' + right(convert(nvarchar(7), getdate(), 23), 5) + '%'

			while @round < 10 and @flag = 0
			begin

				begin try

					select @maxId = max(right(t.serviceNo,6)) from ServiceInfo t with(nolock)
					where t.serviceNo like @format

					set @maxId = isnull(@maxId,0) + 1
					set @serviceNo = replace(@format, '%', right('000000' + cast(@maxId as nvarchar), 6))

					update t set serviceNo = @serviceNo
					from ServiceInfo t
					where t.is_active = 1
					and t.id = @id

					set @flag = 1

				end try
				begin catch

					/* เลขชนกับคนอื่น วนหาเลขใหม่ */
					set @serviceNo = null

				end catch

				set @round = @round + 1

			end

			/* ออกเลขไม่สำเร็จ ต้องแจ้ง ห้ามปล่อยให้เงียบ
			   ไม่งั้นหน้าจอจะไม่ขึ้นอะไรเลยเหมือนเดิม */
			if isnull(@serviceNo,'') = ''
			begin

				raiserror(N'ไม่สามารถออกเลขที่ใบคำขอได้ กรุณาลองใหม่อีกครั้ง', 16, 1)
				return

			end

		end

		update t set status = 'Request'
		from ServiceInfo t
		where t.is_active = 1
		and t.id = @id

		update t set status = dbo.fn_service_next_status(@id)
		, requestBy = @userBy
		, requestDate = getdate()
		from ServiceInfo t
		where t.is_active = 1
		and t.id = @id

		/* Share My */
		--if @requestBy != @userBy
		--begin

		--	exec up_service_cc_ins @id, @userBy, @userBy

		--end

		/* Mail */
		--exec up_service_mail_approve @id
		--exec up_service_mail_cc @id

	end
	else
	begin

		raiserror(N'สถานะใบงานไม่ถูกต้อง ไม่สามารถส่งต่อได้', 16, 1)

	end
end
GO


/* ============================================================================
   [2] up_service_request_upd  :  ต้องแก้ด่านตรวจสิทธิ์ด้วย

   ของเดิม
       if (
           select count(*)
           from ServiceInfo t with(nolock)
           where t.is_active = 1
           and t.id = @id
           and t.createBy = @userBy
       ) > 0

   แก้เป็น
       if (
           select count(*)
           from ServiceInfo t with(nolock)
           where t.is_active = 1
           and t.id = @id
           and (
               t.createBy = @userBy
               or t.userId = @userBy          /* << เพิ่ม : เจ้าของใบส่งเองได้ */
           )
       ) > 0

   ไม่ได้เขียน ALTER เต็มให้ เพราะ raiserror ในนั้นเป็นข้อความไทยที่อ่านมาเพี้ยน
   ถ้าเขียนทับจะทำข้อความเดิมพัง แก้บล็อกนี้ใน SSMS ปลอดภัยกว่า

   *** ตรวจก่อนว่าหน้า FormUpdate เรียก proc ตัวไหน ***
   ถ้าเรียกแต่ _resend อย่างเดียว ข้อ 2 นี้ยังไม่จำเป็นทันที
   แต่ควรแก้ไว้ เพราะถ้าเส้นทางไหนเรียกตัวนี้ พนักงานจะโดน raiserror ทันที
   ============================================================================ */


/* ============================================================================
   ตรวจผลหลังรัน
   ============================================================================ */
-- 1. ใบที่สร้างแทน สถานะและเลขที่เป็นอย่างไร
SELECT  id, status, ISNULL(serviceNo, N'(ยังไม่มีเลขที่)') AS serviceNo
      , createBy, userId, batchId
FROM    ServiceInfo WITH(NOLOCK)
WHERE   createMode = 'OnBehalfDraft'
ORDER BY createDate DESC;
GO

-- 2. หลังพนักงานกดส่ง ใบนั้นต้องได้เลขที่และพ้นสถานะ Draft
--    ถ้ายังเป็น Draft และเลขที่ยังว่าง แปลว่ายังไม่ผ่าน แจ้งมาได้
GO
