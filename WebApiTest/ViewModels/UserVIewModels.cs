using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest.ViewModels {
    public class OwnerViewModel {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }

    public class OwnerCreateViewModel {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }

    public class OwnerUpdateViewModel {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }

    public class OwnerDeleteViewModel {
        public int Id { get; set; }
    }

    public class DriverViewModel {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }

    public class DriverCreateViewModel {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }

    public class DriverUpdateViewModel {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }

    public class DriverDeleteViewModel {
        public int Id { get; set; }
    }
}