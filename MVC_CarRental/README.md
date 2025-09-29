# 🚗 MVC Car Rental: A Car Rental Management System

**MVC Car Rental** is a comprehensive car rental management system developed using **ASP.NET Core MVC** and **Entity Framework Core**. This project provides a web-based solution for managing cars, customers, rental transactions, and users. It features integrated **FluentValidation** to enforce business rules and ensure data integrity.

Built with **.NET 9.0** and modern web development practices.

---

## ✨ Key Features

* **Comprehensive CRUD Operations:** Complete customer management with Create, Read, Update, Delete functionality
* **Entity-Based Domain Model:** Clean architecture with well-defined entities (Brand, Series, Vehicle, Customer, Employee, Office, Rental)
* **Smart Data Validation:** Advanced validation using **FluentValidation** with Turkish character support
* **Database Seeding:** Automatic population of sample data for testing and demonstration
* **Modern UI:** Responsive Razor Views with clean, user-friendly interface
* **Scalable Architecture:** Maintainable ASP.NET Core MVC architecture following best practices
* **Code-First Migrations:** Database schema management with EF Core migrations
* **Audit Trail:** Built-in tracking of creation, update, and deletion timestamps
* **Soft Delete Support:** Safe deletion with recovery capabilities
* **Professional Code Quality:** Comprehensive XML documentation and clean code practices

---

## 🛠️ Tech Stack

| Category | Technology | Version | Description |
|---|---|---|---|
| **Framework** | ASP.NET Core MVC | 9.0 | Microsoft's modern Model-View-Controller framework |
| **Language** | C# | 12.0 | Primary programming language |
| **ORM** | Entity Framework Core | 9.0.9 | Modern ORM for database operations |
| **Validation** | FluentValidation | 12.0.0 | Robust validation library |
| **Database** | SQL Server | Latest | Primary database system |
| **Frontend** | Razor Views, HTML5, CSS3 | - | Server-side rendering with modern web standards |
| **IDE** | Visual Studio 2022+ | - | Recommended development environment |

---

## 📂 Entities (Domain Models)

The system is structured around the following main entities:

* **Brand:** Car manufacturers (e.g., BMW, Mercedes, Toyota, Ford)
* **Series:** Vehicle model series within brands (e.g., BMW X5, Mercedes C-Class)
* **Vehicle:** Individual cars available for rental with specifications
* **Customer:** Customer information and contact details
* **Employee:** Staff members managing rentals and operations
* **Office:** Branch locations where vehicles are managed
* **Rental:** Rental transactions and booking history
* **BaseEntity:** Common properties for all entities (Id, CreatedDate, etc.)

---

## 🧾 Validation Layer

Advanced validation rules implemented with **FluentValidation** for robust data integrity:

* **Customer Validation:** 
  - National ID: 11-digit Turkish format validation
  - Names: Turkish character support with length validation
  - Email: Comprehensive email format validation
  - Phone: Turkish phone number format (+90 555 123 4567)
* **Extensible Design:** Easy to add validation rules for other entities
* **Server-Side Validation:** Ensures data integrity at the application level
* **User-Friendly Messages:** Clear, descriptive error messages in English

---

## 📂 Project Structure

```
MVC_CarRental.sln              # Solution file
MVC_CarRental/                 # Main ASP.NET Core MVC project
├── Controllers/               # Application controllers
│   └── CustomersController.cs # Customer management controller
├── Models/                    # Domain models
│   ├── BaseEntity.cs         # Base entity class
│   ├── Brand.cs              # Brand entity
│   ├── Series.cs             # Series entity
│   ├── Vehicle.cs            # Vehicle entity
│   ├── Customer.cs           # Customer entity
│   ├── Employee.cs           # Employee entity
│   ├── Office.cs             # Office entity
│   ├── Rental.cs             # Rental entity
│   └── Enums/                # Enumeration types
├── Data/                      # Data access layer
│   └── ApplicationDbContext.cs # Entity Framework context
├── Mappings/                  # Entity configurations
├── Validators/                # FluentValidation classes
├── Extentions/                # Extension methods
├── Views/                     # Razor views (UI templates)
├── Migrations/                # Entity Framework migrations
├── ScreenShots/               # Application screenshots
├── appsettings.json          # Application configuration
└── Program.cs                # Application entry point
```

---

## 🚀 Getting Started

### Prerequisites

* **Visual Studio 2022** (or later) or **Visual Studio Code**
* **.NET 9.0 SDK**
* **SQL Server** (LocalDB, Express, or Full Edition)
* **Git** (for cloning the repository)

### Installation Steps

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/MVC_CarRental.git
   cd MVC_CarRental
   ```

2. **Open the solution:**
   ```bash
   # Using Visual Studio
   start MVC_CarRental.sln
   
   # Or using VS Code
   code .
   ```

3. **Restore NuGet packages:**
   ```bash
   dotnet restore
   ```

4. **Configure the database:**
   - Update the connection string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DbConn": "Server=(localdb)\\mssqllocaldb;Database=CarRentalDB;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

5. **Run database migrations:**
   ```bash
   dotnet ef database update
   ```

6. **Build and run the application:**
   ```bash
   dotnet build
   dotnet run
   ```

7. **Access the application:**
   - Open your browser and navigate to `https://localhost:5001` or `http://localhost:5000`

---

## 🆕 Recent Updates

### Version 2.0 - Code Quality & Documentation Improvements

* **Enhanced Code Readability:**
  - Comprehensive XML documentation for all classes and methods
  - Organized code structure with regions and clear separation of concerns
  - Improved variable naming and code formatting

* **Advanced Validation:**
  - Turkish character support in name validation
  - Enhanced phone number format validation
  - Improved error messages for better user experience

* **Database Improvements:**
  - Comprehensive database seeding with realistic sample data
  - Support for 8 brands, 18 series, 18 vehicles, 15 customers, 5 employees, 5 offices, and 8 rentals
  - Automatic data population on first run

* **Professional Code Structure:**
  - Helper methods for duplicate data checking
  - Improved error handling and validation flow
  - Better separation between create and update operations

---

## 📸 Screenshots

### Customer Management Interface

### Screenshots will be added via GitHub Issues

**To add screenshots:**
1. Go to [Issues](https://github.com/dugerdev/MVCCarRental/issues)
2. Create a new issue titled "Screenshots"
3. Drag and drop the screenshot files from `ScreenShots/` folder
4. GitHub will generate direct links
5. Copy those links and update this README

**Screenshot files available:**
- `Create-Customers.png` - Customer creation form
- `Customer-Index.png` - Customer listing page  
- `Update-Customers.png` - Customer editing form
- `Delete-Customers.png` - Customer deletion confirmation

**Alternative: Direct file access**
- [Create Customer Screenshot](ScreenShots/Create-Customers.png)
- [Customer Index Screenshot](ScreenShots/Customer-Index.png)
- [Update Customer Screenshot](ScreenShots/Update-Customers.png)
- [Delete Customer Screenshot](ScreenShots/Delete-Customers.png)

### Key Features Demonstrated

- **Responsive Design:** Clean, modern interface that works on all devices
- **Form Validation:** Real-time validation with user-friendly error messages
- **Data Integrity:** Duplicate prevention for email, phone, and national ID
- **Professional UI:** Bootstrap-based styling with intuitive navigation

## 🤝 Contributing

Contributions are welcome! If you'd like to contribute to this project, please follow these steps:

1. **Fork the repository**
2. **Create a feature branch:** `git checkout -b feature/new-feature`
3. **Commit your changes:** `git commit -m 'Add some feature'`
4. **Push to the branch:** `git push origin feature/new-feature`
5. **Submit a pull request**

### Development Guidelines

- Follow C# coding conventions
- Write meaningful commit messages
- Add appropriate validation for new features
- Update documentation as needed
- Test your changes thoroughly

---

## 📄 License

This project is licensed under the MIT License – see the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 Author

**Muhammad Duger**
- GitHub: [@dugerdev](https://github.com/dugerdev)
- LinkedIn: [Muhammad Duger](https://linkedin.com/in/muhammad-duger)

---

## 🙏 Acknowledgments

- Built with ASP.NET Core MVC
- Entity Framework Core for data access
- FluentValidation for input validation
- Modern web development practices