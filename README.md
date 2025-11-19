---

# 📌 Employee Management System

A secure, full-stack Employee Management System built using **Angular (frontend)** and **ASP.NET Core Web API (backend)**.
This system supports CRUD operations, form validations, input sanitization, user-friendly UI, and secure server communication.

---

## 📂 Project Structure

```
EmployeeManagementSystem/
│
├── backend/
│   ├── Controllers/
│   ├── Models/
│   ├── Services/
│   ├── appsettings.json
│   ├── Program.cs
│   ├── EmployeeManagementSystem.csproj
│
└── frontend/
    ├── src/
    │   ├── app/
    │   │   ├── core/
    │   │   │   ├── services/
    │   │   │   ├── models/
    │   │   ├── components/
    │   │   │   ├── employee-add/
    │   │   │   ├── employee-list/
    │   │   │   ├── employee-edit/
    │   ├── assets/
    │   ├── environments/
    ├── angular.json
    ├── package.json
```

---

# 🧑‍💻 Technologies Used

### **Frontend (Angular 17+)**

* Angular Standalone Components
* TypeScript
* Reactive Forms
* HttpClient for API communication
* Bootstrap / Custom CSS
* Routing + Guards (optional)

### **Backend (ASP.NET Core 7/8 Web API)**

* Controllers & Dependency Injection
* Model Validations
* Secure Input Validation
* File-based storage (JSON file instead of Database)
* CORS enabled for Angular

---

# ⭐ Features

### **Frontend**

* Add Employee
* Edit Employee
* Delete Employee
* List Employees
* Client-side validations
* Clean UI (buttons, forms, layout)
* Reusable service & model architecture

### **Backend**

* REST API
* Input validation
* XSS protection (filters malicious characters)
* JSON file used as local storage
* Endpoint-level error handling
* Status codes with proper HttpResponse

---

# ⚙️ Backend Setup (ASP.NET Core)

### **1️⃣ Navigate to backend folder**

```sh
cd backend
```

### **2️⃣ Restore dependencies**

```sh
dotnet restore
```

### **3️⃣ Run the backend**

```sh
dotnet run
```

### **Default API URL**

```
http://localhost:5213/api/employee
```

---

# 📌 Backend API Endpoints

## ➤ **GET: Get all employees**

```
GET /api/employee
```

## ➤ **GET: Get employee by ID**

```
GET /api/employee/{id}
```

## ➤ **POST: Add new employee**

```
POST /api/employee
```

**Body Example**

```json
{
  "name": "John Doe",
  "department": "HR",
  "salary": 20000
}
```

## ➤ **PUT: Update employee**

```
PUT /api/employee/{id}
```

## ➤ **DELETE: Delete employee**

```
DELETE /api/employee/{id}
```

---

# 🖥️ Frontend Setup (Angular)

### **1️⃣ Navigate to the Angular folder**

```sh
cd frontend
```

### **2️⃣ Install node modules**

```sh
npm install
```

### **3️⃣ Start development server**

```sh
ng serve --open
```

### **Frontend default URL**

```
http://localhost:4200/
```

---

# 🔗 Connecting Frontend & Backend

### In `employee.service.ts`

```ts
apiUrl = 'http://localhost:5213/api/employee';
```

### CORS configuration (Backend → Program.cs)

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});
```

Use:

```csharp
app.UseCors("AllowAngular");
```

---

# 🛡 Security Implemented

### ✔ Server-side validation

### ✔ Sanitization to prevent XSS

Example:

```csharp
if (ContainsMaliciousChars(emp.Name))
    return BadRequest("Invalid characters in input.");
```

### ✔ Model validation using DataAnnotations

### ✔ JSON file protected using safe read/write operations

---

# 🎨 UI Modules

### **Employee List**

* Fetch all employees
* Show in table
* Edit/Delete actions

### **Add Employee**

* Reactive Forms
* Validation (name, salary, etc.)
* Error messages

### **Edit Employee**

* Pre-filled form
* Updates data via PUT

---

# 💾 JSON File Storage (No Database)

Employees stored in:

```
/backend/Data/employees.json
```

Example:

```json
[
  {
    "id": 1,
    "name": "Ravi Kumar",
    "department": "Engineering",
    "salary": 35000
  }
]
```

---

# 🧪 Testing Workflow

### **Postman / Thunder Client**

* Test each endpoint
* Validate error handling

### **Browser DevTools**

* Network tab for API requests

---

# 📤 How to Push the Project to GitHub (Terminal)

### Step 1: Initialize repo

```sh
git init
```

### Step 2: Add all files

```sh
git add .
```

### Step 3: Commit

```sh
git commit -m "Initial commit - Employee Management System"
```

### Step 4: Add remote

```sh
git remote add origin <your_repo_url>
```

### Step 5: Push

```sh
git push -u origin main
```

---

# 🚀 Future Enhancements

* JWT Authentication
* Role-based access
* Pagination & filtering in UI
* Export employee list to Excel/PDF
* Docker support
* Unit tests (Jasmine/Karma + xUnit)

---

# 🏁 How to Run the Project End-to-End

### ✔ Step 1: Start Backend

`dotnet run`

### ✔ Step 2: Start Frontend

`ng serve`

### ✔ Step 3: Open browser

`http://localhost:4200/`

Everything will be fully connected.

---

# 📘 License

This project is open-source and free to use.

---
