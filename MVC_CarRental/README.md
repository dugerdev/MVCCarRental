# 🚗 MVC Car Rental: A Car Rental Management System

**MVC Car Rental** is a comprehensive car rental management system developed using **ASP.NET Core MVC** and **Entity Framework Core**. This project provides a web-based solution for managing cars, customers, rental transactions, and users. It features integrated **FluentValidation** to enforce business rules and ensure data integrity.

Built with **.NET 9.0** and modern web development practices.

---

## ✨ Key Features

* **Comprehensive Management:** Easily manage customers (Create, Read, Update, Delete)
* **Entity-Based Domain Model:** Clean architecture with well-defined entities (Brand, Series, Vehicle, Customer, Employee, Office, Rental)
* **Smart Data Validation:** Utilizes **FluentValidation** library for robust input validation
* **Database-First Approach:** Entity Framework Core with SQL Server integration
* **Modern UI:** Responsive Razor Views with clean user interface
* **Scalable Architecture:** Maintainable ASP.NET Core MVC architecture following best practices
* **Code-First Migrations:** Database schema management with EF Core migrations

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

Validation rules are implemented with **FluentValidation** to guarantee consistent and secure data entry:

* **Customer Validation:** Name format, email validation, phone number format
* **Extensible Design:** Easy to add validation rules for other entities
* **Server-Side Validation:** Ensures data integrity at the application level

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

## 📸 Screenshots

### Customer Management Interface

![Create Customer](ScreenShots/Create.png)
*Creating a new customer record*

![Customer Index](ScreenShots/Index.png)
*Customer listing and management*

![Update Customer](ScreenShots/Update.png)
*Editing customer information*

![Delete Customer](ScreenShots/Delete.png)
*Customer deletion confirmation*

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