# RTT.Assessment

## 📖 Technology Used
 - ⚡ .NET Core & C# ( Visual Studion 2026
 - ⚡ Local SQL Server
   
---

## Database ERD

```mermaid
erDiagram
  Persons ||--o{ Contacts : has
  Persons ||--o{ Addresses : has
  Persons {
    int Id PK "NOT NULL"
    nvarchar Name "NULL"
    nvarchar Surname "NULL"
    int Age "NOT NULL"
    date DOB "NOT NULL"
    datetime DateCreated "NOT NULL"
    datetime DateUpdated "NOT NULL"
  }
  Contacts {
    int Id PK "NOT NULL"
    nvarchar Email "NULL"
    nvarchar PhoneNumber "NULL"
    nvarchar CellNumber "NULL"
    int PersonId FK "NOT NULL"
    datetime DateCreated "NOT NULL"
    datetime DateUpdated "NOT NULL"
  }
  Addresses {
    int Id PK "NOT NULL"
    nvarchar Street "NULL"
    nvarchar City "NULL"
    nvarchar Province "NULL"
    nvarchar Country "NULL"
    nvarchar PostalCode "NULL"
    int AddressType "NOT NULL"
    int PersonId FK "NOT NULL"
    datetime DateCreated "NOT NULL"
    datetime DateUpdated "NOT NULL"
  }

---
```

