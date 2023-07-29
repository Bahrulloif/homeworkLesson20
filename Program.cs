dowhile (true)
{
    System.Console.WriteLine("Choose table : ");
    System.Console.WriteLine("\n Table: \n d - Department \n e - Employee \n m - Manager \n");
    var chooseTable = Console.ReadLine();
    if (chooseTable == "d")
    {
        var departmentService = new DepartmentService();

        while (true)
        {
            System.Console.WriteLine("\n Commands: \n r - all records \n c - for create \n i - by ID \n u - update \n b - break \n");
            var command = Console.ReadLine();
            if (command == "r")
                Read();
            else if (command == "c")
                Create();
            else if (command == "i")
                ReadById();
            else if (command == "u")
                Update();
            else if (command == "b")
                break;
        }

        void Read()
        {
            var deps = departmentService.GetDepartments();
            foreach (var item in deps)
            {
                System.Console.Write(item.Id);
                System.Console.Write($" {item.Name} ");
                System.Console.Write($" {item.ManagerId} ");
                System.Console.Write($" {item.ManagerFullName}");
                System.Console.WriteLine();
            }
        }

        void ReadById()
        {
            System.Console.WriteLine("Enter ID : ");
            var id = Convert.ToInt32(Console.ReadLine());
            var depsid = departmentService.GetDepartmentById(id);


            System.Console.Write(depsid.Id);
            System.Console.Write($" {depsid.Name} ");
            System.Console.Write($" {depsid.ManagerId} ");
            System.Console.Write($" {depsid.ManagerFullName}");
            System.Console.WriteLine();

        }

        void Create()
        {
            var department = new Department();
            System.Console.Write("Enter Id : ");
            department.Id = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Name : ");
            department.Name = Console.ReadLine();
            // System.Console.Write("Enter Manager");
            // department.ManagerId=Convert.ToInt32(Console.ReadLine());
            // System.Console.Write("Enter ManagerFullName");
            // department.ManagerFullName=Console.ReadLine();
            departmentService.Insert(department);
        }

        void Update()
        {
            System.Console.WriteLine("Enter ID");
            var id = Convert.ToInt32(Console.ReadLine());
            var depsid = departmentService.GetDepartmentById(id);
            System.Console.WriteLine("Enter Name of Department : ");
            depsid.Name = Console.ReadLine();
            departmentService.UpdateDepartment(depsid);
        }
    }
    else if (chooseTable == "e")
    {
        // __________________________________________________________________________________________________________________________


        var employeeService = new EmployeeService();

        while (true)
        {
            System.Console.WriteLine("\n Commands: \n r - all records \n c - for create \n i - by ID \n u - update \n b - break \n");
            var command = Console.ReadLine();
            if (command == "r")
                Read();
            else if (command == "c")
                Create();
            else if (command == "i")
                ReadById();
            else if (command == "u")
                Update();
                            else if (command == "b")
                break;
        }

        void Read()
        {
            foreach (var item in employeeService.GetEmployee())
            {
                System.Console.Write(item.Id);
                System.Console.Write($" {item.Firstname} {item.Lastname} ");
                System.Console.Write($" {item.DepartmentId} ");
                System.Console.Write($" {item.DepartmentName} ");
                System.Console.WriteLine();
            }
        }

        void ReadById()
        {
            System.Console.Write("Enter ID : ");
            var id = Convert.ToInt32(Console.ReadLine());
            var item = employeeService.GetEmployeeById(id);

            System.Console.Write(item.Id);
            System.Console.Write($" {item.Firstname} {item.Lastname} ");
            System.Console.Write($" {item.DepartmentId} ");
            System.Console.Write($" {item.DepartmentName} ");
            System.Console.WriteLine();
        }

        void Create()
        {
            var emp = new Employee();
            System.Console.WriteLine("Enter Id for insert : ");
            emp.Id = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Enter the birthdate : ");
            System.Console.Write("Enter the year : ");
            var year1 = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter the month : ");
            var month1 = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter the day : ");
            var day1 = Convert.ToInt32(Console.ReadLine());
            DateTime date1 = new DateTime(year1, month1, day1);
            emp.Birthdate = date1;
            System.Console.Write("Enter FirstName : ");
            emp.Firstname = Console.ReadLine();
            System.Console.Write("Enter LastName : ");
            emp.Lastname = Console.ReadLine();
            System.Console.Write("Enter the HireDate : ");
            System.Console.Write("Enter the year : ");
            var year2 = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter the month : ");
            var month2 = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter the day : ");
            var day2 = Convert.ToInt32(Console.ReadLine());
            DateTime date2 = new DateTime(year1, month1, day1);
            emp.Hiredate = date2;
            System.Console.Write("Enter the Gender (1-Male or 2-Female) : ");
            var inputGender = Convert.ToInt32(Console.ReadLine());
            emp.Gender = (Gender)inputGender;
            employeeService.Insert(emp);
        }

        void Update()
        {
            System.Console.WriteLine("Enter Id for insert : ");
            var id = Convert.ToInt32(Console.ReadLine());
            var emp = employeeService.GetEmployeeById(id);

            System.Console.WriteLine("Enter the birthdate : ");
            System.Console.Write("Enter the year : ");
            var year1 = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter the month : ");
            var month1 = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter the day : ");
            var day1 = Convert.ToInt32(Console.ReadLine());
            DateTime date1 = new DateTime(year1, month1, day1);
            emp.Birthdate = date1;
            System.Console.Write("Enter FirstName : ");
            emp.Firstname = Console.ReadLine();
            System.Console.Write("Enter LastName : ");
            emp.Lastname = Console.ReadLine();
            System.Console.Write("Enter the HireDate : ");
            System.Console.Write("Enter the year : ");
            var year2 = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter the month : ");
            var month2 = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter the day : ");
            var day2 = Convert.ToInt32(Console.ReadLine());
            DateTime date2 = new DateTime(year1, month1, day1);
            emp.Hiredate = date2;
            System.Console.Write("Enter the Gender (1-Male or 2-Female) : ");
            var inputGender = Convert.ToInt32(Console.ReadLine());
            emp.Gender = (Gender)inputGender;
            employeeService.UpdateEmployee(emp);
        }
    }
    else if (chooseTable == "m")
    {

        // _____________________________________________________________________________


        var managerService = new ManagerService();

        while (true)
        {
            System.Console.WriteLine("\n Commands: \n r - all records \n c - for create \n b - break \n");
            var command = Console.ReadLine();
            if (command == "r")
                Read();
            else if (command == "c")
                Create();
                            else if (command == "b")
                break;
        }

        void Read()
        {
            foreach (var item in managerService.GetManagers())
            {
                System.Console.Write(item.ManagerId);
                System.Console.Write($" {item.ManagerFullName}");
                System.Console.Write($" {item.DepartmentId} ");
                System.Console.Write($" {item.DepartmentName} ");
                System.Console.Write($" {item.FromDate} ");
                System.Console.Write($" {item.ToDate} ");
                System.Console.WriteLine();
            }


        }

        void Create()
        {

            var manag = new Manager();
            System.Console.Write("Enter manaderId :");
            manag.ManagerId = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Enter DepartmentID : ");
            manag.DepartmentId = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Enter fromdate : ");
            manag.FromDate = Convert.ToDateTime(Console.ReadLine());

        }
    }
}