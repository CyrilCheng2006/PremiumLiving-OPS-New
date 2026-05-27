# PremiumLiving-OPS-New

**PremiumLiving Furniture Operations System**  
Windows Forms Application · MySQL Database · Visual Studio 2022 · .NET 8

## Project Structure

```
PremiumLiving-OPS-New/
├── PremiumLivingOPS.sln
├── database/
│   ├── schema-2.sql
│   ├── log_schema.sql
│   └── simple_data-3.sql
└── PremiumLivingOPS/
    ├── PremiumLivingOPS.csproj
    ├── Program.cs
    ├── Helpers/
    │   ├── DBHelper.cs
    │   └── SessionManager.cs
    ├── Forms/
    │   ├── LoginForm.cs / .Designer.cs
    │   ├── MainForm.cs / .Designer.cs
    │   ├── DashboardForm.cs / .Designer.cs
    │   ├── CustomerListForm.cs / .Designer.cs
    │   ├── OrderListForm.cs / .Designer.cs
    │   ├── NewOrderForm.cs / .Designer.cs
    │   ├── QuotationForm.cs / .Designer.cs
    │   ├── InvoiceForm.cs / .Designer.cs
    │   ├── ComplaintListForm.cs / .Designer.cs
    │   ├── ScheduleDeliveryForm.cs / .Designer.cs
    │   ├── TrackShipmentForm.cs / .Designer.cs
    │   ├── DeliveryNoteForm.cs / .Designer.cs
    │   ├── ReplySlipForm.cs / .Designer.cs
    │   ├── StockLevelForm.cs / .Designer.cs
    │   ├── StockAlertForm.cs / .Designer.cs
    │   ├── StockReportForm.cs / .Designer.cs
    │   ├── PurchaseOrderForm.cs / .Designer.cs
    │   ├── SupplierListForm.cs / .Designer.cs
    │   ├── TransferForm.cs / .Designer.cs
    │   ├── MaterialRequestForm.cs / .Designer.cs
    │   ├── AccountsRecvForm.cs / .Designer.cs
    │   ├── AccountsPayForm.cs / .Designer.cs
    │   ├── FinReportForm.cs / .Designer.cs
    │   ├── UserMgmtForm.cs / .Designer.cs
    │   ├── AuditLogForm.cs / .Designer.cs
    │   ├── SysConfigForm.cs / .Designer.cs
    │   ├── ReturnMgmtForm.cs / .Designer.cs
    │   └── ProductInfoForm.cs / .Designer.cs
    └── Models/
        ├── Staff.cs
        ├── Customer.cs
        ├── Supplier.cs
        ├── Item.cs
        ├── Product.cs
        ├── RawMaterial.cs
        ├── Order.cs
        ├── OrderLine.cs
        ├── Quotation.cs
        ├── Invoice.cs
        ├── Shipment.cs
        ├── DeliveryNote.cs
        ├── Complaint.cs
        ├── PurchaseOrder.cs
        ├── WarehouseItem.cs
        └── TransferForm.cs
```

## Setup

1. Install MySQL 8.x and run `database/schema-2.sql` then `database/log_schema.sql` then `database/simple_data-3.sql`
2. Open `PremiumLivingOPS.sln` in Visual Studio 2022
3. Update connection string in `Helpers/DBHelper.cs`
4. Build and run

## Default Login

| StaffID | Password | Role |
|---------|----------|------|
| S-001   | (see DB) | Administrator |

## Colour Theme (matches HTML prototype)

| Token | Hex |
|-------|-----|
| Primary dark | `#1a1a2e` |
| Accent gold  | `#c9a84c` |
| Surface white | `#ffffff` |
| Text muted   | `#6c757d` |
