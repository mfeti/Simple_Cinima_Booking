
---

# 🎬 SIMPLE CINIMA BOOKING  

A lightweight ASP.NET Core ticket booking system for cinemas.  

---

## 🚀 **Quick Start**  

### **Prerequisites**  
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)  
- SQL Server (LocalDB) or SQLite  

### **Run Locally**  
1. Clone the repo:  
   ```bash
   git clone https://github.com/your-username/Simple_Cinema_Booking.git
   cd Simple_Cinema_Booking
   ```  
2. Restore & run:  
   ```bash
   dotnet restore
   dotnet run
   ```  
3. Open in browser:  
   🔗 [http://localhost:5000](http://localhost:5000)  

---

## ⚙️ **Configuration**  
### Database Setup  
1. Update `appsettings.json`:  
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CinemaDB;Trusted_Connection=True;"
   }
   ```  
2. Apply migrations:  
   ```bash
   dotnet ef database update
   ```  

---

## ✨ **Features**  
- Browse movies & showtimes  
- Secure user authentication  
- Ticket purchase flow  
- Admin panel (manage movies, actors, etc.)  

---

## 📜 **License**  
MIT © 2023 – Free to use, modify, and distribute.  

---

## ❓ **Support**  
Got stuck? Email [mfeti2175@gmail.com](mailto:mfeti2175@gmail.com) or open an issue.  

--- 
