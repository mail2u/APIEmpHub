/* ============================================================================
   แก้บั๊กตัวกรองใน up_user_sel : คนที่ไม่มีฝ่าย รอดทุกตัวกรองเสมอ

   อาการ
     เลือกฝ่ายงานใน dropdown แล้วยังเห็นพนักงานจากหน่วยงานอื่นติดมา
     สังเกตได้ว่าคนที่ติดมาคือคนที่คอลัมน์ฝ่ายแสดงเป็นชื่อชั้นอื่น
     เช่น "ด้านเทคโนโลยี" "สายงาน..." "ทีมผู้บริหาร" ซึ่งไม่ใช่ระดับฝ่าย

   สาเหตุ
     ใน #data คอลัมน์ ue.departmentCode / ue.divisionCode / ue.functionCode
     ไม่ได้ครอบ isnull() ต่างจาก sectionCode และ positionCode ที่ครอบไว้

         , ue.departmentCode                      <- ไม่มี isnull
         , isnull(t.section,'') as sectionCode     <- มี
         , isnull(t.position,'') as positionCode   <- มี

     ตัวกรองเทียบด้วย !=
         delete t from #data t where t.departmentCode != @departmentCode

     ใน SQL Server  NULL != 'อะไรก็ตาม'  ให้ผลเป็น UNKNOWN ไม่ใช่ TRUE
     where ที่ได้ UNKNOWN จะไม่เข้าเงื่อนไข DELETE จึงไม่ลบแถวนั้น
     ผลคือพนักงานที่ departmentCode เป็น NULL รอดตัวกรองฝ่ายทุกครั้ง

   ขอบเขตผลกระทบ
     ทุกหน้าที่กรองด้วยฝ่ายผ่าน User/DataList รั่วแบบเดียวกันมาตลอด
       Service/OnBehalf , Employee/Index , EmpManage/Index , Report/Employee
       และ dropdown เลือกหัวหน้า

   วิธีแก้ : ครอบ isnull() ที่ตัวกรอง ไม่ใช่ที่ select
             แก้ที่ตัวกรองพอ และไม่กระทบคอลัมน์ที่หน้าจออ่านอยู่
   ============================================================================ */

USE [EmpHub]
GO

/* ----------------------------------------------------------------------------
   แก้ใน up_user_sel  เปลี่ยนบล็อกนี้

       if @departmentCode != ''
       begin

           delete t
           from #data t
           where t.departmentCode != @departmentCode

       end

   เป็น

       if @departmentCode != ''
       begin

           delete t
           from #data t
           where isnull(t.departmentCode,'') != @departmentCode

       end

   *** ไม่ได้เขียน ALTER เต็มให้ เพราะ up_user_sel ถูกแก้ไปแล้วรอบหนึ่ง
       ใน 2026-08-09_alter_user_sel_summary_offboard_filter.sql
       ถ้าเขียนทับจากสำเนาเก่าจะทับ inner join v_user_working ที่เพิ่มไว้หาย
       แก้บรรทัดเดียวใน SSMS ปลอดภัยกว่า ---------------------------------- */


/* ----------------------------------------------------------------------------
   ตรวจก่อนแก้ : ดูว่ามีพนักงานที่ไม่มีฝ่ายกี่คน
   ถ้าได้ 0 แปลว่าอาการมาจากสาเหตุอื่น ให้หยุดแล้วตรวจเพิ่ม
   ---------------------------------------------------------------------------- */
SELECT  COUNT(*) AS no_department
FROM    UserInfo u WITH(NOLOCK)
        INNER JOIN UserEmployeeInfo ue WITH(NOLOCK) ON u.userId = ue.userId AND ue.is_active = 1
WHERE   u.is_active = 1
  AND   ISNULL(ue.departmentCode, '') = '';
GO

/* ตรวจหลังแก้ : เลือกฝ่ายใดก็ได้ 1 ฝ่าย ผลลัพธ์ต้องไม่มีคนที่ departmentCode ว่าง
   DECLARE @t INT
   EXEC up_user_sel @firstname_th='', @departmentCode='<รหัสฝ่าย>', @positionCode='',
        @employeeType='', @dateFrom='', @dateTo='', @page=1, @row=50, @sortBy='', @total=@t OUTPUT
   SELECT @t AS total                                                            */
GO


/* ============================================================================
   ยังมีจุดเดียวกันที่ควรแก้พร้อมกัน  (ยังไม่ได้แก้)

   ในไฟล์เดียวกันมีบล็อกที่ปลอดภัยอยู่แล้วเพราะ select ครอบ isnull ไว้
       @positionCode  ->  isnull(t.position,'') as positionCode      ปลอดภัย
       @employeeType  ->  isnull(ue.employeeType,'') as employeeType ปลอดภัย

   แต่ถ้าภายหลังเพิ่มตัวกรองด้วย divisionCode หรือ functionCode
   จะเจอปัญหาเดียวกันทันที เพราะสองคอลัมน์นั้นก็ไม่ได้ครอบ isnull
       , ue.divisionCode
       , ue.functionCode

   ทางที่สะอาดกว่าคือครอบ isnull ที่ select ให้ครบทั้งสามคอลัมน์
   แต่ต้องตรวจก่อนว่าหน้าจอไหนแยกแยะ NULL กับค่าว่างอยู่หรือไม่
   เช่น ผังองค์กร Team/Company ที่ใช้ค่าว่างเป็นสัญญาณว่ายังไม่ได้กำหนดหน่วยงาน
   ============================================================================ */
