# หน้าจัดการ : สร้างใบงาน Draft แทนผู้ใช้งาน

คู่กับ `2026-08-11_add_service_draft_onbehalf.sql`

---

## ที่ตั้ง

ใช้ **`EmpHub/Pages/Service/Manage.cshtml`** ที่มีอยู่แล้ว
ตอนนี้ว่างเปล่า มีแค่ `@page` + `@model EmpHub.Pages.Service.ManageModel`
มี PageModel รออยู่แล้ว ไม่ต้องสร้างใหม่

ต้องเพิ่มลิงก์ในเมนู `Service/_PartialNavBar` ด้วย

---

## โครงหน้า (ตามแพตเทิร์น Work.cshtml เป๊ะ)

```
@section PageHeader { ... breadcrumb ... }

<div ng-controller="ServiceCtrl">

    1) แถบหัว + แท็บกรองสถานะ พร้อมตัวเลขนับ
       <div class="d-md-flex">
           <div class="fs-4 me-3">จัดการใบงานแทนผู้ใช้</div>
           แท็บ : ทั้งหมด | รอกรอกข้อมูล | ส่งแล้ว | ยกเลิก
           ใช้ ng-click="SelectStatus('Draft')" และ badge {{ sum_draft | number }}

    2) <div class="rounded-4 p-3 bg-white shadow-sm border mb-4">
           <partial name="Service/_PartialNavBar" />
       </div>

    3) <partial name="_PartialManageDataList"></partial>

</div>

<script> app.controller('ServiceCtrl', function ($scope, $http, $timeout, $filter) { ... }) </script>
```

**ปุ่มสร้าง** วางมุมขวาบนของแถบแท็บ
`+ สร้างใบงานแทนผู้ใช้` → เปิด modal ตัวช่วย 3 ขั้น (ดูข้างล่าง)

### สิ่งที่ต้องคงไว้ให้เหมือนหน้าอื่น

| | ค่า |
|---|---|
| ชื่อ controller | `ServiceCtrl` |
| จำนวนต่อหน้า | `$scope.row = 10` |
| ฟังก์ชันหลัก | `LoadData(page = 1)` , `LoadSummary()` , `SelectStatus(s)` |
| ตัวแปรกรอง | `$scope.iStatus = ''` |
| ข้อมูล | `$scope.lData = []` |

---

## แท็บและสถานะ

| แท็บ | เงื่อนไข | ความหมาย |
|---|---|---|
| ทั้งหมด | `''` | ใบที่ฉันสร้างแทนคนอื่นทั้งหมด |
| รอกรอกข้อมูล | `Draft` | สร้างแล้ว พนักงานยังไม่กรอก |
| ส่งแล้ว | `Request` ขึ้นไป | พนักงานกรอกและส่งเข้าสายอนุมัติแล้ว |
| ยกเลิก | `Cancel` | ยกเลิกทิ้ง |

**ประเด็นที่ต่างจากหน้าอื่น** — Approve/Work/Inquire กรองจาก "ใบที่ฉันต้องทำ"
แต่หน้านี้กรองจาก **`createBy = ฉัน` และ `userId != ฉัน`** คือใบที่ฉันตั้งให้คนอื่น
ต้องเขียน proc ใหม่ ใช้ `up_service_work_sel` เป็นต้นแบบไม่ได้ตรง ๆ

---

## คอลัมน์ในตาราง (`_PartialManageDataList.cshtml`)

ลอกโครงจาก `_PartialWorkDataList.cshtml` แล้วเปลี่ยนคอลัมน์

| คอลัมน์ | มาจาก |
|---|---|
| เลขที่ใบงาน | `serviceNo` |
| ประเภทฟอร์ม | `subCategoryDesc` |
| ผู้ที่ต้องกรอก | `userName` (จาก `t.userId`) |
| ฝ่าย / ส่วน | `userDepartment` |
| สถานะ | `statusDesc` + `statusCss` |
| วันที่สร้าง | `createDate` |
| จัดการ | ปุ่มยกเลิก (เฉพาะ `Draft`) , ปุ่มเตือน |

ควรมีปุ่ม **"เตือนพนักงาน"** สำหรับใบที่ค้างเป็น Draft นาน
ไม่งั้น HR สร้างทิ้งไว้แล้วไม่มีใครตาม งานจะค้างเงียบ ๆ

---

## Modal สร้างใบงาน 3 ขั้น

### ขั้น 1 — เลือกประเภทฟอร์ม
เรียก `Category/AuthenList` (ตัวเดียวกับที่ `Service/New.cshtml` ใช้)
คืนเฉพาะฟอร์มที่ผู้ใช้มีสิทธิ์อยู่แล้ว ไม่ต้องทำ permission เพิ่ม

### ขั้น 2 — เลือกกลุ่มผู้ใช้
ลอกแพตเทิร์นจาก `SurveySetting/Index.cshtml`
โหลด `MasterCode/DataList` groupName `departmentCode` ครั้งเดียว
แล้วแยกชั้นด้วย `condition_4`

| ค่า condition_4 | ชั้น |
|---|---|
| `Business Unit` | ด้าน |
| `Group` | สาย |
| `Department` | ฝ่าย |
| `Section` | ส่วน |

กรองลูกด้วย `condition_3 = รหัสแม่`

จากนั้นโหลด `User/DataList` มาแสดงรายชื่อที่เข้าเงื่อนไข
ให้ **ติ๊กออกรายคนได้** ก่อนยืนยัน เพราะกรองตามหน่วยงานมักได้คนที่ไม่ต้องการติดมาด้วย

> **ห้ามผูกฟังก์ชันกรองใน `ng-options` / `ng-repeat`**
> ต้องสร้าง array คงที่ไว้ใน scope ไม่งั้น digest วนไม่จบ
> (บทเรียนจาก `/Profile` — `[$rootScope:infdig]`)

### ขั้น 3 — ยืนยัน
สรุปให้เห็นก่อนกด : ฟอร์มอะไร / กี่คน / รายชื่อ
แล้วยิง `Service/CreateBulk`

---

## API : `Service/CreateBulk`

รับ list ของ `userId` แล้ววนสร้างในฝั่ง server
**อย่าวนจากหน้าจอ** เพราะเลือก 200 คนจะยิง API 200 ครั้ง
ช้า และถ้าหลุดกลางทางจะสร้างค้างครึ่ง ๆ กลาง ๆ

เรียก `up_service_ins` โดยส่ง

| พารามิเตอร์ | ค่า |
|---|---|
| `@userId` | พนักงานแต่ละคน |
| `@createBy` | `User.UserId()` (HR) |
| `@status` | `'Draft'` |

`requestBy` proc ใส่ `@userId` ให้เอง — ผู้ขอตัวจริงคือพนักงาน

**ควรครอบ transaction** ให้สร้างครบทุกคนหรือไม่สร้างเลย
และกันสร้างซ้ำ — ถ้าพนักงานคนนั้นมีใบ Draft ประเภทเดียวกันค้างอยู่แล้ว ให้ข้าม

---

## เรียกกลับ / ยกเลิก (กติกาที่เจ้าของงานกำหนด 2026-08-13)

**ยกเลิกได้เฉพาะภายในวันที่สร้าง และภายในวันนั้นยกเลิกได้ทุกใบ ไม่จำกัดสถานะ**

เจตนาคือให้แก้ความผิดพลาดได้ทันทีที่รู้ตัว แต่พ้นวันไปแล้วห้ามไปรบกวนงานที่เดินไปแล้ว

เงื่อนไขที่ proc ต้องเช็ค

```sql
and t.createBy = @userBy
and t.createMode = 'OnBehalfDraft'
and cast(t.createDate as date) = cast(getdate() as date)
and t.status <> 'Cancel'
```

**"ภายในวัน" ตีความเป็นวันตามปฏิทิน ไม่ใช่ 24 ชั่วโมง** — สร้าง 23:50 แล้วเที่ยงคืนผ่านไปคือยกเลิกไม่ได้แล้ว
ถ้าต้องการเป็น 24 ชั่วโมงให้เปลี่ยนเป็น `t.createDate >= dateadd(hour,-24,getdate())`

### สิ่งที่ต้องทำ

- **SQL** `up_service_onbehalf_cancel_batch` รับ `@batchId` + `@userBy`
  คืนจำนวนที่ยกเลิกได้และจำนวนที่หมดสิทธิ์ เพื่อให้หน้าจอแจ้งผลตรงความจริง
- **API** `Service/CancelBatch` บังคับ `userBy` จาก token
- **UI** จัดกลุ่มรายการตาม `batchId` มีปุ่ม "เรียกกลับทั้งชุด"
  ซ่อนหรือ disable ปุ่มเมื่อพ้นวันแล้ว ไม่ใช่ให้กดแล้วค่อยขึ้น error

### ⚠️ ต้องตรวจก่อนทำ

การยกเลิกใบที่พ้นสถานะ Draft ไปแล้วกระทบของอื่นด้วย ไม่ใช่แค่เปลี่ยน `status`

1. **`ServiceStepInfo`** — ใบที่เข้าสายอนุมัติแล้วมีแถว step ผูกกับ `refId` ต้องดูว่าปล่อยค้างไว้ได้หรือต้องปิดด้วย
2. **คิวของคนอนุมัติ / คนทำงาน** — `up_service_approve_sel` และ `up_service_work_sel` กรองด้วย status ถ้าเป็น `Cancel` ควรหลุดออกเอง แต่ต้องยืนยัน
3. **ใบที่ `Complete` แล้ว** — เจ้าของงานสั่งว่า "ทุกใบ" ผมจะทำตามนั้น แต่ขอบันทึกไว้ว่าเคสนี้เสี่ยงที่สุด เพราะงานทำเสร็จไปแล้วจริง การย้อนเป็น Cancel จะทำให้ประวัติขัดกับสิ่งที่เกิดขึ้น ถ้าอยากกันไว้ให้เพิ่ม `and t.status <> 'Complete'`
4. **พนักงานที่กรอกข้อมูลไปแล้ว** จะเสียงานฟรี ควรมีข้อความยืนยันบอกจำนวนคนที่กรอกแล้วก่อนกดจริง

## ยังค้างอยู่ (จากไฟล์ SQL)

- **B2** `up_service_detail` : เพิ่ม `when t.status = 'Draft' then N'รอกรอกข้อมูล'` ในบล็อก `statusDesc`
- **C** `up_service_request_sel` : ต้องให้ใบ Draft โผล่ในลิสต์ของพนักงาน ไม่งั้นฟีเจอร์ใช้ไม่ได้เลย
