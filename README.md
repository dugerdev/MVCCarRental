# MVC Car Rental System

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-9.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-green.svg)](https://docs.microsoft.com/en-us/aspnet/core/)

A comprehensive car rental management system built with .NET 9.0 MVC framework.

## 🚀 Features

- **Customer Management**: Full CRUD operations with validation
- **Vehicle Management**: Brand, series, and vehicle tracking
- **Employee Management**: Staff and office management
- **Rental Operations**: Complete rental workflow
- **Advanced Validation**: FluentValidation with Turkish character support
- **Database Seeding**: Pre-populated with realistic sample data
- **Responsive Design**: Modern, clean interface

## 🛠️ Tech Stack

- **.NET 9.0** - Latest framework version
- **ASP.NET Core MVC** - Web application framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Database management
- **FluentValidation** - Advanced validation rules
- **Bootstrap** - Responsive UI framework

## 📋 Prerequisites

- .NET 9.0 SDK
- SQL Server (LocalDB or Express)
- Visual Studio 2022 or VS Code

## 🚀 Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/dugerdev/MvcCarRental.git
   cd MvcCarRental
   ```

2. **Navigate to project directory:**
   ```bash
   cd MVC_CarRental
   ```

3. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

4. **Update database:**
   ```bash
   dotnet ef database update
   ```

5. **Run the application:**
   ```bash
   dotnet run
   ```

6. **Access the application:**
   - Open your browser and navigate to `https://localhost:5001` or `http://localhost:5000`

## 📊 Database Schema

### Entities

- **BaseEntity**: Common properties (Id, IsDeleted, CreatedOn, UpdatedOn, DeletedOn)
- **Customer**: Customer information with validation
- **Vehicle**: Vehicle details with brand and series relationships
- **Brand**: Vehicle manufacturer information
- **Series**: Vehicle model information
- **Employee**: Staff management
- **Office**: Office locations
- **Rental**: Rental transaction records

### Sample Data

The application comes with pre-seeded data:
- 8 Brands (Toyota, BMW, Mercedes, etc.)
- 18 Series (Corolla, X5, C-Class, etc.)
- 18 Vehicles with various specifications
- 15 Sample customers
- 5 Employees
- 5 Office locations
- 8 Sample rental records

## 📸 Screenshots

### 🎯 Application Interface Overview

This section showcases the key features and user interface of the MVC Car Rental System. The screenshots demonstrate the complete customer management workflow with modern, responsive design.

---

### 👥 Customer Management System

#### 📋 Customer List View
![Customer List](ScreenShots/Customer-list.png)
*Comprehensive customer listing with search, filter, and management capabilities. Features include pagination, sorting, and quick action buttons for each customer record.*

#### ➕ Create New Customer
![Create Customer](ScreenShots/Customer-create.png)
*Intuitive customer creation form with real-time validation, duplicate checking, and user-friendly error messages. The form includes comprehensive field validation for Turkish characters.*

#### ✏️ Edit Customer Information
![Edit Customer](ScreenShots/customer-edit.png)
*Customer information editing interface with pre-populated fields, validation feedback, and seamless update functionality. Includes duplicate prevention and data integrity checks.*

#### 🗑️ Delete Customer Confirmation
![Delete Customer](ScreenShots/Customer-delete.png)
*Safe customer deletion process with confirmation dialog, soft delete implementation, and audit trail maintenance. Ensures data integrity while providing user safety.*

---

### 🎨 UI/UX Features Demonstrated

- **Modern Design**: Clean, professional interface with Bootstrap styling
- **Responsive Layout**: Works seamlessly across desktop, tablet, and mobile devices
- **Form Validation**: Real-time validation with clear error messaging
- **User Feedback**: Intuitive success/error notifications
- **Data Integrity**: Comprehensive validation and duplicate prevention
- **Accessibility**: User-friendly interface with clear navigation

---

### 🔧 Technical Features Showcased

- **CRUD Operations**: Complete Create, Read, Update, Delete functionality
- **FluentValidation**: Advanced validation rules with Turkish character support
- **Soft Delete**: Safe data deletion with audit trail
- **Search & Filter**: Advanced data filtering and search capabilities
- **Error Handling**: Comprehensive error management and user feedback

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

## 🔧 Key Features Demonstrated

- **Responsive Design:** Clean, modern interface that works on all devices
- **Form Validation:** Real-time validation with user-friendly error messages
- **CRUD Operations:** Complete Create, Read, Update, Delete functionality
- **Duplicate Prevention:** Advanced duplicate checking for customers
- **Soft Delete:** Safe deletion with IsDeleted flag
- **Audit Trail:** CreatedOn, UpdatedOn, DeletedOn tracking

## 📁 Project Structure
