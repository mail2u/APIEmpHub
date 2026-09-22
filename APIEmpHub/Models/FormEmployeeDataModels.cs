namespace APIEmpHub.Models
{
    public class FormEmployeeDataModels
    {
        public string refId { get; set; }
        public int is_username { get; set; }
        public int is_prefix_th { get; set; }
        public int is_prefix_en { get; set; }
        public int is_fullname_th { get; set; }
        public int is_fullname_en { get; set; }
        public int is_position { get; set; }        // ตำแหน่ง (ไทย)
        public int is_position_en { get; set; }     // ตำแหน่ง (อังกฤษ)
        public int is_employee_type_th { get; set; }
        public int is_employee_type_en { get; set; }
        public int is_department { get; set; }       // สังกัดฝ่าย (ไทย)
        public int is_department_en { get; set; }    // สังกัดฝ่าย (อังกฤษ)
        public int is_division_th { get; set; }      // สังกัดสาย (ไทย)
        public int is_division_en { get; set; }      // สังกัดสาย (อังกฤษ)
        public int is_function_th { get; set; }      // สังกัดด้าน (ไทย)
        public int is_function_en { get; set; }      // สังกัดด้าน (อังกฤษ)
        public int is_join_date { get; set; }        // วันที่เริ่มงาน
        public int is_resign_date { get; set; }      // วันที่มีผลลาออก
        public int is_employee_code { get; set; }    // รหัสพนักงาน
        public int is_nickname { get; set; }         // ชื่อเล่น
        public int is_email { get; set; }
        public string description { get; set; }
        public string create_by { get; set; }
    }
}
