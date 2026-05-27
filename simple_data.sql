/* basic set up */

INSERT INTO Staff (StaffID, StaffName, StaffRole, Email, StaffPassword, Department) VALUES
('S-001', 'IT Admin',         'Administrator',  'it.admin@plf.com',   'admin123', 'IT'),
('S-002', 'Chan Ho Yuen',     'Manager',        'chy@plf.com',        'prod456',  'Production'),
('S-003', 'Lam Siu Keung',    'Staff',          'lsk@plf.com',        'log789',   'Logistics'),
('S-004', 'Wong Kin Ho',      'Clerk',          'wkm.sales@plf.com',  'sales321', 'Sales'),
('S-005', 'Chan Wai Man',     'Manager',          'cwm@plf.com',        'wh001',    'Inventory'),
('S-006', 'Ng Pak Hei',       'Manager',        'finance@plf.com',    'fin888',   'Finance'),
('S-007', 'Yeung Chi Wai',    'Delivery person','ycw@plf.com',        'drv999',   'Logistics'),
('S-008', 'James Mitchell',   'Manager',        'j.mitchell@plf.com', 'lon001',   'Inventory'),
('S-009', 'Yuki Tanaka',      'Manager',        'y.tanaka@plf.com',   'tok001',   'Inventory'),
('S-010', 'Maria Gonzalez',   'Manager',        'm.gonzalez@plf.com', 'la001',    'Inventory');

INSERT INTO Warehouse (WarehouseID, ManagerID, WarehouseLocation, ContactNumber, Capacity) VALUES
('WH-2026-00001', 'S-005', '12 Container Port Road, Kwai Chung, New Territories, Hong Kong',         '+852-2456-7890',    5000),
('WH-2026-00002', 'S-002', '88 Longhua Avenue, Longhua District, Shenzhen, Guangdong, China 518109', '+86-755-8800-1234', 4000),
('WH-2026-00003', 'S-008', 'Unit 5, Meridian Business Park, Leicester Road, London, UK, NW10 7HE',   '+44-20-7946-0123',  3500),
('WH-2026-00004', 'S-009', '3-1-2 Ariake, Koto-ku, Tokyo, Japan 135-0063',                          '+81-3-5500-2200',   2500),
('WH-2026-00005', 'S-010', '4200 E Concours St, Ontario, Los Angeles, CA 91764, USA',               '+1-909-456-7800',   3000);

/* item set up */

INSERT INTO Item (ItemID, ItemName, ItemDescription) VALUES
('IID-P-0001', 'Nordic 3-Seater Sofa',      'Scandinavian design, linen fabric'),
('IID-P-0002', 'Queen Size Oak Bed Frame',   'Solid oak, queen size 60x80 inch'),
('IID-P-0003', 'Marble Dining Table 6-seat', 'White marble top, steel legs'),
('IID-P-0004', 'Ergonomic Office Chair',     'Mesh back, adjustable lumbar'),
('IID-P-0005', '5-Door Wardrobe',            'MDF board, mirror door included'),
('IID-R-0001', 'Solid Oak Panel',            'Grade A solid oak timber board'),
('IID-R-0002', 'High-density Foam',          'Foam density 80D, 2-inch thick'),
('IID-R-0003', 'Steel Bolt Set',             'Stainless steel M8 bolt set'),
('IID-R-0004', 'Fabric Roll Linen Grey',     'Linen grey upholstery fabric 50m'),
('IID-R-0005', 'Plywood 18mm',               'Birch plywood 18mm 4x8 sheet'),
('IID-R-0006', 'Metal Frame 40x40',          'Square steel tube 40x40x1.5mm'),
('IID-R-0007', 'Lacquer Coat Clear',         'Clear lacquer coat 20L can');

INSERT INTO Product (ItemID, SalesPrice, Category) VALUES
('IID-P-0001', 12800.00, 'Sofa'),
('IID-P-0002', 8500.00,  'Bed'),
('IID-P-0003', 18000.00, 'Table'),
('IID-P-0004', 3200.00,  'Chair'),
('IID-P-0005', 14500.00, 'Cabinet');

INSERT INTO RawMaterial (ItemID, purchasePrice, MaterialType) VALUES
('IID-R-0001', 280.00, 'Wood'),
('IID-R-0002', 150.00, 'Foam'),
('IID-R-0003', 12.00,  'Metal'),
('IID-R-0004', 85.00,  'Fabric'),
('IID-R-0005', 95.00,  'Wood'),
('IID-R-0006', 45.00,  'Metal'),
('IID-R-0007', 320.00, 'Paint');

INSERT INTO WarehouseItem (WarehouseItemID, ItemID, WarehouseID, WarehouseItemQuantity, ReorderLevel) VALUES
-- WH-001 --> product
('WHI-P-0001', 'IID-P-0001', 'WH-2026-00001', 15, 5),
('WHI-P-0002', 'IID-P-0002', 'WH-2026-00001', 8,  5),
('WHI-P-0003', 'IID-P-0003', 'WH-2026-00001', 4,  3),
('WHI-P-0004', 'IID-P-0004', 'WH-2026-00001', 22, 10),
('WHI-P-0005', 'IID-P-0005', 'WH-2026-00001', 5,  8),
-- WH-002 --> rawmaterial
('WHI-R-0001', 'IID-R-0001', 'WH-2026-00002', 8,  20),
('WHI-R-0002', 'IID-R-0002', 'WH-2026-00002', 3,  15),
('WHI-R-0003', 'IID-R-0003', 'WH-2026-00002', 12, 50),
('WHI-R-0004', 'IID-R-0004', 'WH-2026-00002', 9,  10),
('WHI-R-0005', 'IID-R-0005', 'WH-2026-00002', 3,  20),
('WHI-R-0006', 'IID-R-0006', 'WH-2026-00002', 55, 30),
('WHI-R-0007', 'IID-R-0007', 'WH-2026-00002', 20, 15),
-- WH-003 --> product
('WHI-P-0006', 'IID-P-0001', 'WH-2026-00003', 10, 5),
('WHI-P-0007', 'IID-P-0002', 'WH-2026-00003', 6,  5),
('WHI-P-0008', 'IID-P-0004', 'WH-2026-00003', 14, 8),
-- WH-004 --> product
('WHI-P-0009', 'IID-P-0001', 'WH-2026-00004', 8,  5),
('WHI-P-0010', 'IID-P-0003', 'WH-2026-00004', 3,  3),
('WHI-P-0011', 'IID-P-0005', 'WH-2026-00004', 6,  5),
-- WH-005 --> product
('WHI-P-0012', 'IID-P-0001', 'WH-2026-00005', 12, 5),
('WHI-P-0013', 'IID-P-0004', 'WH-2026-00005', 18, 10),
('WHI-P-0014', 'IID-P-0002', 'WH-2026-00005', 7,  5);

/* supplier & customer & address set up */

INSERT INTO Supplier (SupplierID, PhoneNumber, SupplierAddress, SupplierName) VALUES
('SUP-2026-0001', '+86-755-8812-3456', '18 Meihua Road, Longhua District, Shenzhen, China 518109',          'Green Wood Co. Ltd'),
('SUP-2026-0002', '+81-3-3456-7890',   '2-5-1 Kiba, Koto-ku, Tokyo, Japan 135-0042',                       'MetalPro Japan'),
('SUP-2026-0003', '+44-161-834-5678',  '14 Trafford Park Road, Manchester, United Kingdom M17 1PF',         'FabricPlus UK Ltd'),
('SUP-2026-0004', '+60-3-8024-9900',   'Lot 8, Jalan Perusahaan, Prai Industrial Estate, Penang, Malaysia', 'TimberLink Sdn Bhd'),
('SUP-2026-0005', '+1-213-456-7890',   '3500 S Figueroa St, Los Angeles, CA 90007, USA',                    'FoamTech USA Inc.');

INSERT INTO Customer (CustomerID, CustomerName, EmailAddress, PhoneNumber) VALUES
('C-1018', 'Chan Siu Ming',       'csm@email.com',              '+852-9123-4567'),
('C-1022', 'Lee Wai Kwan',        'lwk@email.com',              '+852-9234-5678'),
('C-1030', 'ABC Furniture Ltd',   'purchase@abcfurniture.com',  '+44-20-7123-4567'),
('C-1038', 'Wong Cheuk Hei',      'wch@email.com',              '+852-9876-5432'),
('C-1042', 'Sunrise Interiors',   'order@sunrise-int.com',      '+1-310-987-6543'),
('C-1055', 'Tanaka Home Design',  'orders@tanakahome.jp',       '+81-3-5678-9012'),
('C-1061', 'Beaumont Living SAS', 'contact@beaumont-living.fr', '+33-1-4256-7890'),
('C-1074', 'Nordic Nest AB',      'procurement@nordicnest.se',  '+46-8-1234-5678');

INSERT INTO Address (AddressID, CustomerID, AddressName, AddressType, isDefault) VALUES
('ADDR-0001', 'C-1018', 'Flat 12B, 88 Nathan Road, Tsim Sha Tsui, Kowloon, Hong Kong',                    'Residential', 1),
('ADDR-0002', 'C-1022', 'Unit 7F, 200 Queens Road West, Sheung Wan, Hong Kong',                            'Residential', 1),
('ADDR-0003', 'C-1030', '12th Floor, The Gherkin, 30 St Mary Axe, London, EC3A 8BF, United Kingdom',      'Office',      1),
('ADDR-0004', 'C-1030', 'Unit 3, Meridian Distribution Park, Braunstone, Leicester, LE3 2WX, UK',          'Mailing',     0),
('ADDR-0005', 'C-1038', 'Room 5B, 35 Boundary Street, Mong Kok, Kowloon, Hong Kong',                      'Residential', 1),
('ADDR-0006', 'C-1042', '1200 Wilshire Blvd, Suite 800, Los Angeles, CA 90017, USA',                      'Office',      1),
('ADDR-0007', 'C-1042', '4321 E La Palma Ave, Anaheim, CA 92807, USA',                                    'Mailing',     0),
('ADDR-0008', 'C-1055', '6F Shibuya Scramble Square, 2-24-12 Shibuya, Shibuya-ku, Tokyo 150-6139, Japan', 'Office',      1),
('ADDR-0009', 'C-1061', '28 Rue du Faubourg Saint-Antoine, 75012 Paris, France',                          'Office',      1),
('ADDR-0010', 'C-1074', 'Kungsgatan 55, 111 22 Stockholm, Sweden',                                        'Office',      1);

/*scenario 1: low inventory level--> Reorder item (without order)*/

INSERT INTO MaterialRequest
  (RequestID, OrderID, RawMaterialItemID, WarehouseItemID, RequestedQty, UrgencyLevel, TriggerType)
VALUES
  ('MRQ-2026-0019', NULL, 'IID-R-0005', 'WHI-R-0005', 20, 'High',     'Reorder'),
  ('MRQ-2026-0020', NULL, 'IID-R-0001', 'WHI-R-0001', 50, 'Critical', 'Reorder'),
  ('MRQ-2026-0021', NULL, 'IID-R-0002', 'WHI-R-0002', 30, 'Critical', 'Reorder'),
  ('MRQ-2026-0022', NULL, 'IID-R-0001', 'WHI-R-0001', 50, 'High',     'Reorder'),
  ('MRQ-2026-0023', NULL, 'IID-R-0004', 'WHI-R-0004', 100, 'High',    'Reorder');

  INSERT INTO PurchaseOrder
  (PurchaseID, RequestID, SupplierID, POTotalAmount, OrderDate, PurchaseStatus)
VALUES
  ('PO-2026-00020', 'MRQ-2026-0019', 'SUP-2026-0004', 7200.00,  '2026-02-15', 'Completed'),
  ('PO-2026-00021', 'MRQ-2026-0020', 'SUP-2026-0001', 14000.00, '2026-03-01', 'Partially Received'),
  ('PO-2026-00022', 'MRQ-2026-0023', 'SUP-2026-0003', 8500.00, '2026-02-20', 'Received'),
  ('PO-2026-00023', 'MRQ-2026-0021', 'SUP-2026-0005', 4500.00,  '2026-02-28', 'Completed'),
  ('PO-2026-00024', 'MRQ-2026-0022', 'SUP-2026-0001', 16400.00, '2026-03-11', 'Sent');

  INSERT INTO PurchaseOrderLine
  (POLineID, RawMaterialItemID, PurchaseID, WarehouseID, OrderQty, UnitPrice)
VALUES
  ('POL-2026-0006', 'IID-R-0005', 'PO-2026-00020', 'WH-2026-00002', 20, 360.00),
  ('POL-2026-0005', 'IID-R-0001', 'PO-2026-00021', 'WH-2026-00002', 50,  280.00),
  ('POL-2026-0003', 'IID-R-0004', 'PO-2026-00022', 'WH-2026-00002', 100, 85.00),
  ('POL-2026-0008', 'IID-R-0002', 'PO-2026-00023', 'WH-2026-00002', 30,  150.00),
  ('POL-2026-0001', 'IID-R-0001', 'PO-2026-00024', 'WH-2026-00002', 50,  280.00),
  ('POL-2026-0002', 'IID-R-0003', 'PO-2026-00024', 'WH-2026-00002', 200, 12.00);

  INSERT INTO PurchaseInvoice
  (PurInvoiceID, PurchaseID, TotalAmount, PaymentStatus, ExpectedDate)
VALUES
  ('PURINV-2026-0033', 'PO-2026-00020', 7200.00,  'Full',    '2026-03-05'),
  ('PURINV-2026-0034', 'PO-2026-00023', 4500.00,  'Full',    '2026-03-08'),
  ('PURINV-2026-0035', 'PO-2026-00022', 8500.00, 'Full',     '2026-03-10'),
  ('PURINV-2026-0039', 'PO-2026-00024', 2400.00,  'Partial', '2026-03-15'),
  ('PURINV-2026-0041', 'PO-2026-00021', 14000.00, 'Partial', '2026-03-20');

  INSERT INTO Receipt
  (ReceiptID, PurchaseID, POLineID, QtyReceived, ReceiptDate, Outstanding_QTY)
VALUES
  ('REC-2026-0002', 'PO-2026-00020', 'POL-2026-0006', 20, '2026-03-08', 0),
  ('REC-2026-0004', 'PO-2026-00022', 'POL-2026-0003', 100, '2026-02-25', 0),
  ('REC-2026-0006', 'PO-2026-00023', 'POL-2026-0008', 30,  '2026-03-05', 0),
  ('REC-2026-0001', 'PO-2026-00021', 'POL-2026-0005', 48,  '2026-03-10', 2);

  INSERT INTO `Transaction`
  (TransactionID, InvoiceID, PurInvoiceID, ReturnID, Amount, TransactionDate, TransactionType)
VALUES
  ('TXN-2026-00009', NULL, 'PURINV-2026-0035', NULL, 8500.00, '2026-03-10', 'Full'),
  ('TXN-2026-00010', NULL, 'PURINV-2026-0033', NULL, 7200.00, '2026-03-08', 'Full'),
  ('TXN-2026-00012', NULL, 'PURINV-2026-0034', NULL, 4500.00, '2026-03-06', 'Full');

/*scenario 2: warehouse transfer*/

INSERT INTO TransferForm (TransferID, TransferDate, TransferStatus) VALUES
('TRF-2026-0001', '2026-03-10', 'Completed'),
('TRF-2026-0002', '2026-03-11', 'Pending'),
('TRF-2026-0003', '2026-03-12', 'Pending');

INSERT INTO WarehouseItem (WarehouseItemID, ItemID, WarehouseID, WarehouseItemQuantity, ReorderLevel) VALUES
('WHI-R-0008', 'IID-R-0001', 'WH-2026-00001', 0, 10); 

INSERT INTO TransferForm_WarehouseItem
  (TransferLineID, TransferID, FromWarehouseItemID, ToWarehouseItemID, TransferQuantity)
VALUES
  ('TRL-2026-00001', 'TRF-2026-0001', 'WHI-P-0001', 'WHI-P-0006', 5),  
  ('TRL-2026-00002', 'TRF-2026-0001', 'WHI-P-0004', 'WHI-P-0008', 10); 

INSERT INTO TransferForm_WarehouseItem
  (TransferLineID, TransferID, FromWarehouseItemID, ToWarehouseItemID, TransferQuantity)
VALUES
  ('TRL-2026-00003', 'TRF-2026-0002', 'WHI-P-0002', 'WHI-P-0009', 4),   
  ('TRL-2026-00004', 'TRF-2026-0002', 'WHI-P-0003', 'WHI-P-0010', 2);  

INSERT INTO TransferForm_WarehouseItem
  (TransferLineID, TransferID, FromWarehouseItemID, ToWarehouseItemID, TransferQuantity)
VALUES
  ('TRL-2026-00005', 'TRF-2026-0003', 'WHI-R-0001', 'WHI-R-0008', 20);   

/*scenario 3: Chan Siu Ming make quotation and confirm purchase (with deposit & without outstanding)*/  

INSERT INTO Quotation (QuotationID, CustomerID, ExpiryDate, TotalAmount, DepositRequired, LeadTimeEstimated, TermsandCondition, QuotationStatus) VALUES
('QT-2026-0034', 'C-1018', '2026-03-29', 38400.00, 7680.00, '7-10 working days', 'Net 30. Deposit required upon confirmation.', 'Converted');

INSERT INTO `Order` (OrderID, QuotationID, CustomerID, AddressID, SalesID,
                     IssuedTime, DeliveryDate, ShippingAddress, BillingAddress,
                     SubTotal, DiscountType, DiscountValue, DiscountAmount, GrandTotal,
                     OrderContactName, OrderStatus) VALUES
('ORD-2026-00033', 'QT-2026-0034', 'C-1018', 'ADDR-0001', 'S-004',
 '2026-03-01', '2026-03-15',
 'Flat 12B, 88 Nathan Road, Tsim Sha Tsui, Kowloon, Hong Kong',
 'Flat 12B, 88 Nathan Road, Tsim Sha Tsui, Kowloon, Hong Kong',
 38400.00, NULL, NULL, 0.00, 38400.00, 'Chan Siu Ming', 'Delivered');

 INSERT INTO OrderLine (OrderID, ItemID, Quantity, Price) VALUES
('ORD-2026-00033', 'IID-P-0001', 2, 12800.00),
('ORD-2026-00033', 'IID-P-0002', 1, 8500.00);

INSERT INTO Invoice (InvoiceID, OrderID, InvoiceDate, DepositAmount, PaidAmount, RemainingBalance, TotalAmount, PaymentStatus, DueDate) VALUES
('INV-2026-00033', 'ORD-2026-00033', '2026-03-01', 7680.00, 38400.00, 0.00, 38400.00, 'Full', '2026-04-01');

INSERT INTO `Transaction` (TransactionID, InvoiceID, PurInvoiceID, ReturnID, Amount, TransactionDate, TransactionType) VALUES
('TXN-2026-00001', 'INV-2026-00033', NULL, NULL, 7680.00,  '2026-03-01', 'Deposit'),
('TXN-2026-00002', 'INV-2026-00033', NULL, NULL, 30720.00, '2026-03-15', 'Installment');

INSERT INTO Shipment (ShipmentID, OrderID, TrackingNumber, ShipDate, DeliveryMethod, ShipmentStatus, ShipmentType, TotalAmount) VALUES
('SHP-2026-0033', 'ORD-2026-00033', 'TRK-0033', '2026-03-15', 'Courier', 'Completed', 'Full', 38400.00);

INSERT INTO ShipmentLine (ShipmentLineID, ShipmentID, OrderID, ItemID, QtyShipped, QtyOutstanding) VALUES
('SHPL-2026-00001', 'SHP-2026-0033', 'ORD-2026-00033', 'IID-P-0001', 2, 0),
('SHPL-2026-00002', 'SHP-2026-0033', 'ORD-2026-00033', 'IID-P-0002', 1, 0);

INSERT INTO DeliveryNote (DeliveryID, ShipmentID, DeliveryDate, Outstanding_qty, ShippingAddress, ShipToName) VALUES
('DN-2026-00033', 'SHP-2026-0033', '2026-03-15', 0,
 'Flat 12B, 88 Nathan Road, Tsim Sha Tsui, Kowloon, Hong Kong', 'Chan Siu Ming');

INSERT INTO ReplySlip (SlipID, DeliveryID, actualRecipient, ReceivedDate, RecipientRemark) VALUES
('RS-2026-00001', 'DN-2026-00033', 'Chan Siu Ming', '2026-03-15', 'All items received in good condition');

/*scenario 4: Lee Wai Kwan (with deposit & without outstanding)*/ 

INSERT INTO Quotation (QuotationID, CustomerID, ExpiryDate, TotalAmount, DepositRequired, LeadTimeEstimated, TermsandCondition, QuotationStatus) VALUES
('QT-2026-0030', 'C-1022', '2026-03-04', 19200.00, 7500.00, '7-10 working days', 'Net 30. Deposit required upon confirmation.', 'Converted');


INSERT INTO `Order` (OrderID, QuotationID, CustomerID, AddressID, SalesID,
                     IssuedTime, DeliveryDate, ShippingAddress, BillingAddress,
                     SubTotal, DiscountType, DiscountValue, DiscountAmount, GrandTotal,
                     OrderContactName, OrderStatus) VALUES
('ORD-2026-00031', 'QT-2026-0030', 'C-1022', 'ADDR-0002', 'S-004',
 '2026-02-28', '2026-03-10',
 'Unit 7F, 200 Queens Road West, Sheung Wan, Hong Kong',
 'Unit 7F, 200 Queens Road West, Sheung Wan, Hong Kong',
 19200.00, NULL, NULL, 0.00, 19200.00, 'Lee Wai Kwan', 'Delivered');

INSERT INTO OrderLine (OrderID, ItemID, Quantity, Price) VALUES
('ORD-2026-00031', 'IID-P-0001', 1, 12800.00),
('ORD-2026-00031', 'IID-P-0004', 2, 3200.00);

INSERT INTO Invoice (InvoiceID, OrderID, InvoiceDate, DepositAmount, PaidAmount, RemainingBalance, TotalAmount, PaymentStatus, DueDate) VALUES
('INV-2026-00031', 'ORD-2026-00031', '2026-02-28', 7500.00, 19200.00, 0.00, 19200.00, 'Full', '2026-03-30');

INSERT INTO `Transaction` (TransactionID, InvoiceID, PurInvoiceID, ReturnID, Amount, TransactionDate, TransactionType) VALUES
('TXN-2026-00003', 'INV-2026-00031', NULL, NULL, 7500.00,  '2026-02-28', 'Deposit'),
('TXN-2026-00004', 'INV-2026-00031', NULL, NULL, 11700.00, '2026-03-10', 'Installment');

INSERT INTO Shipment (ShipmentID, OrderID, TrackingNumber, ShipDate, DeliveryMethod, ShipmentStatus, ShipmentType, TotalAmount) VALUES
('SHP-2026-0031', 'ORD-2026-00031', 'TRK-0031', '2026-03-10', 'Courier', 'Completed', 'Full', 19200.00);

INSERT INTO ShipmentLine (ShipmentLineID, ShipmentID, OrderID, ItemID, QtyShipped, QtyOutstanding) VALUES
('SHPL-2026-00003', 'SHP-2026-0031', 'ORD-2026-00031', 'IID-P-0001', 1, 0),
('SHPL-2026-00004', 'SHP-2026-0031', 'ORD-2026-00031', 'IID-P-0004', 2, 0);

INSERT INTO DeliveryNote (DeliveryID, ShipmentID, DeliveryDate, Outstanding_qty, ShippingAddress, ShipToName) VALUES
('DN-2026-00031', 'SHP-2026-0031', '2026-03-10', 0,
 'Unit 7F, 200 Queens Road West, Sheung Wan, Hong Kong', 'Lee Wai Kwan');

INSERT INTO ReplySlip (SlipID, DeliveryID, actualRecipient, ReceivedDate, RecipientRemark) VALUES
('RS-2026-00002', 'DN-2026-00031', 'Lee Wai Kwan', '2026-03-10', NULL);

INSERT INTO Complaint (ComplaintID, OrderID, StaffID, ComplaintDescription, ComplaintStatus) VALUES
('CMP-2026-0005', 'ORD-2026-00031', 'S-004', 'Damaged sofa leg upon delivery', 'Completed');

/*scenario 5: ABC Furniture Ltd*/ 

INSERT INTO Quotation (QuotationID, CustomerID, ExpiryDate, TotalAmount, DepositRequired, LeadTimeEstimated, TermsandCondition, QuotationStatus) VALUES
('QT-2026-0029', 'C-1030', '2026-03-20', 116100.00, 23220.00, '10-14 working days', 'Net 45. Corporate account terms apply.', 'Converted');

INSERT INTO `Order` (OrderID, QuotationID, CustomerID, AddressID, SalesID,
                     IssuedTime, DeliveryDate, ShippingAddress, BillingAddress,
                     SubTotal, DiscountType, DiscountValue, DiscountAmount, GrandTotal,
                     OrderContactName, OrderStatus) VALUES
('ORD-2026-00029', 'QT-2026-0029', 'C-1030', 'ADDR-0004', 'S-004',
 '2026-02-25', '2026-03-09',
 'Unit 3, Meridian Distribution Park, Braunstone, Leicester, LE3 2WX, UK',
 '12th Floor, The Gherkin, 30 St Mary Axe, London, EC3A 8BF, United Kingdom',
116100.00, NULL, NULL, 0.00, 116100.00, 'ABC Furniture Ltd', 'Partially Delivered');

INSERT INTO OrderLine (OrderID, ItemID, Quantity, Price) VALUES
('ORD-2026-00029', 'IID-P-0001', 2, 12800.00),
('ORD-2026-00029', 'IID-P-0003', 1, 18000.00),
('ORD-2026-00029', 'IID-P-0005', 5, 14500.00);

INSERT INTO Invoice (InvoiceID, OrderID, InvoiceDate, DepositAmount, PaidAmount, RemainingBalance, TotalAmount, PaymentStatus, DueDate) VALUES
('INV-2026-00029', 'ORD-2026-00029', '2026-02-25', 23220.00, 23220.00, 92880.00, 116100.00, 'Partial', '2026-03-25');

INSERT INTO `Transaction` (TransactionID, InvoiceID, PurInvoiceID, ReturnID, Amount, TransactionDate, TransactionType) VALUES
('TXN-2026-00008', 'INV-2026-00029', NULL, NULL, 23220.00, '2026-02-25', 'Deposit');

INSERT INTO Shipment (ShipmentID, OrderID, TrackingNumber, ShipDate, DeliveryMethod, ShipmentStatus, ShipmentType, TotalAmount) VALUES
('SHP-2026-0029A', 'ORD-2026-00029', 'TRK-0029', '2026-03-09', 'Courier', 'Delivered', 'Partial', 25600.00),
('SHP-2026-0029B', 'ORD-2026-00029', 'TRK-0030', '2026-03-12', 'Courier', 'Delivered',   'Partial', 47000.00),
('SHP-2026-0029C', 'ORD-2026-00029', 'TRK-0029C', '2026-03-18', 'Courier', 'Pending', 'Partial', 43500.00);

INSERT INTO ShipmentLine (ShipmentLineID, ShipmentID, OrderID, ItemID, QtyShipped, QtyOutstanding) VALUES
('SHPL-2026-00005', 'SHP-2026-0029A', 'ORD-2026-00029', 'IID-P-0001', 2, 0),
('SHPL-2026-00006', 'SHP-2026-0029B', 'ORD-2026-00029', 'IID-P-0003', 1, 0),
('SHPL-2026-00007', 'SHP-2026-0029B', 'ORD-2026-00029', 'IID-P-0005', 2, 3),
('SHPL-2026-00012', 'SHP-2026-0029C', 'ORD-2026-00029', 'IID-P-0005', 3, 0);

INSERT INTO DeliveryNote (DeliveryID, ShipmentID, DeliveryDate, Outstanding_qty, ShippingAddress, ShipToName) VALUES
('DN-2026-00029A', 'SHP-2026-0029A', '2026-03-09', 0,
 'Unit 3, Meridian Distribution Park, Braunstone, Leicester, LE3 2WX, UK', 'ABC Furniture Ltd'),
('DN-2026-00029B', 'SHP-2026-0029B', '2026-03-12', 3,
 'Unit 3, Meridian Distribution Park, Braunstone, Leicester, LE3 2WX, UK', 'ABC Furniture Ltd'),
('DN-2026-00029C', 'SHP-2026-0029C', '2026-03-18', 0,
 'Unit 3, Meridian Distribution Park, Braunstone, Leicester, LE3 2WX, UK', 'ABC Furniture Ltd');
 ;

INSERT INTO ReplySlip (SlipID, DeliveryID, actualRecipient, ReceivedDate, RecipientRemark) VALUES
('RS-2026-00003', 'DN-2026-00029A', 'ABC Furniture Ltd', '2026-03-09', 'Partial delivery confirmed'),
('RS-2026-00004B', 'DN-2026-00029B', 'ABC Furniture Ltd', '2026-03-12', 'Dining Table received. 3 Wardrobes outstanding');

INSERT INTO Complaint (ComplaintID, OrderID, StaffID, ComplaintDescription, ComplaintStatus) VALUES
('CMP-2026-0003', 'ORD-2026-00029', 'S-004', 'Wrong colour delivered - table', 'Completed'),
('CMP-2026-0001', 'ORD-2026-00029', 'S-004', 'Late delivery - 3 days overdue',    'Completed');

/*scenario 6: Wong Cheuk Hei (normal scenario with no quoatation and full payment)*/ 

INSERT INTO `Order` (OrderID, QuotationID, CustomerID, AddressID, SalesID,
                     IssuedTime, DeliveryDate, ShippingAddress, BillingAddress,
                     SubTotal, DiscountType, DiscountValue, DiscountAmount, GrandTotal,
                     OrderContactName, OrderStatus) VALUES
('ORD-2026-00045', NULL, 'C-1038', 'ADDR-0005', 'S-004',
 '2026-03-08', '2026-03-10',
 '22 Peak Road, The Peak, Hong Kong',
 'Room 5B, 35 Boundary Street, Mong Kok, Kowloon, Hong Kong',
 26500.00, NULL, NULL, 0.00, 26500.00, 'Wong Cheuk Hei', 'Delivered');

INSERT INTO OrderLine (OrderID, ItemID, Quantity, Price) VALUES
('ORD-2026-00045', 'IID-P-0003', 1, 18000.00),
('ORD-2026-00045', 'IID-P-0002', 1, 8500.00);

INSERT INTO Invoice (InvoiceID, OrderID, InvoiceDate, DepositAmount, PaidAmount, RemainingBalance, TotalAmount, PaymentStatus, DueDate) VALUES
('INV-2026-00027', 'ORD-2026-00045', '2026-03-08', 0.00, 26500.00, 0.00, 26500.00, 'Full', '2026-04-07');

INSERT INTO `Transaction` (TransactionID, InvoiceID, PurInvoiceID, ReturnID, Amount, TransactionDate, TransactionType) VALUES
('TXN-2026-00005', 'INV-2026-00027', NULL, NULL, 26500.00, '2026-03-10', 'Full');

INSERT INTO Shipment (ShipmentID, OrderID, TrackingNumber, ShipDate, DeliveryMethod, ShipmentStatus, ShipmentType, TotalAmount) VALUES
('SHP-2026-0045', 'ORD-2026-00045', 'TRK-0045', '2026-03-10', 'Courier', 'Completed', 'Full', 26500.00);

INSERT INTO ShipmentLine (ShipmentLineID, ShipmentID, OrderID, ItemID, QtyShipped, QtyOutstanding) VALUES
('SHPL-2026-00008', 'SHP-2026-0045', 'ORD-2026-00045', 'IID-P-0003', 1, 0),
('SHPL-2026-00009', 'SHP-2026-0045', 'ORD-2026-00045', 'IID-P-0002', 1, 0);

INSERT INTO DeliveryNote (DeliveryID, ShipmentID, DeliveryDate, Outstanding_qty, ShippingAddress, ShipToName) VALUES
('DN-2026-00045', 'SHP-2026-0045', '2026-03-10', 0,
 '22 Peak Road, The Peak, Hong Kong', 'Wong Cheuk Hei');

INSERT INTO ReplySlip (SlipID, DeliveryID, actualRecipient, ReceivedDate, RecipientRemark) VALUES
('RS-2026-00004', 'DN-2026-00045', 'Wong Cheuk Hei', '2026-03-10', 'Received all items in good order');

/*scenario 7: Sunrise Interiors (normal scenario with deposit and full payment)*/ 

INSERT INTO Quotation (QuotationID, CustomerID, ExpiryDate, TotalAmount, DepositRequired, LeadTimeEstimated, TermsandCondition, QuotationStatus) VALUES
('QT-2026-0028', 'C-1042', '2026-03-15', 56000.00, 11200.00, '7-10 working days', 'Net 30.', 'Converted');

INSERT INTO `Order` (OrderID, QuotationID, CustomerID, AddressID, SalesID,
                     IssuedTime, DeliveryDate, ShippingAddress, BillingAddress,
                     SubTotal, DiscountType, DiscountValue, DiscountAmount, GrandTotal,
                     OrderContactName, OrderStatus) VALUES
('ORD-2026-00044', 'QT-2026-0028', 'C-1042', 'ADDR-0007', 'S-004',
 '2026-03-07', '2026-03-08',
 '4321 E La Palma Ave, Anaheim, CA 92807, USA',
 '1200 Wilshire Blvd, Suite 800, Los Angeles, CA 90017, USA',
 57600.00, 'Rate', 5.00, 2880.00, 54720.00, 'Sunrise Interiors', 'Delivered');

INSERT INTO OrderLine (OrderID, ItemID, Quantity, Price) VALUES
('ORD-2026-00044', 'IID-P-0001', 3, 12800.00),
('ORD-2026-00044', 'IID-P-0004', 6, 3200.00);

INSERT INTO Invoice (InvoiceID, OrderID, InvoiceDate, DepositAmount, PaidAmount, RemainingBalance, TotalAmount, PaymentStatus, DueDate) VALUES
('INV-2026-00044', 'ORD-2026-00044', '2026-03-07', 11200.00, 54720.00, 0.00, 54720.00, 'Full', '2026-04-06');

INSERT INTO `Transaction` (TransactionID, InvoiceID, PurInvoiceID, ReturnID, Amount, TransactionDate, TransactionType) VALUES
('TXN-2026-00006', 'INV-2026-00044', NULL, NULL, 54720.00, '2026-03-08', 'Full');

INSERT INTO Shipment (ShipmentID, OrderID, TrackingNumber, ShipDate, DeliveryMethod, ShipmentStatus, ShipmentType, TotalAmount) VALUES
('SHP-2026-0044', 'ORD-2026-00044', 'TRK-0044', '2026-03-08', 'Courier', 'Completed', 'Full', 54720.00);

INSERT INTO ShipmentLine (ShipmentLineID, ShipmentID, OrderID, ItemID, QtyShipped, QtyOutstanding) VALUES
('SHPL-2026-00010', 'SHP-2026-0044', 'ORD-2026-00044', 'IID-P-0001', 3, 0),
('SHPL-2026-00011', 'SHP-2026-0044', 'ORD-2026-00044', 'IID-P-0004', 6, 0);

INSERT INTO DeliveryNote (DeliveryID, ShipmentID, DeliveryDate, Outstanding_qty, ShippingAddress, ShipToName) VALUES
('DN-2026-00044', 'SHP-2026-0044', '2026-03-08', 0,
 '4321 E La Palma Ave, Anaheim, CA 92807, USA', 'Sunrise Interiors');

INSERT INTO ReplySlip (SlipID, DeliveryID, actualRecipient, ReceivedDate, RecipientRemark) VALUES
('RS-2026-00005', 'DN-2026-00044', 'Sunrise Interiors', '2026-03-08', NULL);

/*scenario 8: Tanaka Home Design (not arrived, partial payment)*/ 

INSERT INTO Quotation (QuotationID, CustomerID, ExpiryDate, TotalAmount, DepositRequired, LeadTimeEstimated, TermsandCondition, QuotationStatus) VALUES
('QT-2026-0035', 'C-1055', '2026-04-05', 47500.00, 9500.00, '7-10 working days', 'Net 30. Deposit required upon confirmation.', 'Converted');

INSERT INTO `Order` (OrderID, QuotationID, CustomerID, AddressID, SalesID,
                     IssuedTime, DeliveryDate, ShippingAddress, BillingAddress,
                     SubTotal, DiscountType, DiscountValue, DiscountAmount, GrandTotal,
                     OrderContactName, OrderStatus) VALUES
('ORD-2026-00051', 'QT-2026-0035', 'C-1055', 'ADDR-0008', 'S-004',
 '2026-03-20', '2026-03-28',
 '6F Shibuya Scramble Square, 2-24-12 Shibuya, Shibuya-ku, Tokyo 150-6139, Japan',
 '6F Shibuya Scramble Square, 2-24-12 Shibuya, Shibuya-ku, Tokyo 150-6139, Japan',
 47500.00, NULL, NULL, 0.00, 47500.00, 'Yuki Nakamura', 'Processing');

INSERT INTO OrderLine (OrderID, ItemID, Quantity, Price) VALUES
('ORD-2026-00051', 'IID-P-0003', 1, 18000.00),
('ORD-2026-00051', 'IID-P-0005', 2, 14500.00);

INSERT INTO Invoice (InvoiceID, OrderID, InvoiceDate, DepositAmount, PaidAmount, RemainingBalance, TotalAmount, PaymentStatus, DueDate) VALUES
('INV-2026-00051', 'ORD-2026-00051', '2026-03-20', 9500.00, 9500.00, 38000.00, 47500.00, 'Partial', '2026-04-20');

INSERT INTO `Transaction` (TransactionID, InvoiceID, PurInvoiceID, ReturnID, Amount, TransactionDate, TransactionType) VALUES
('TXN-2026-00013', 'INV-2026-00051', NULL, NULL, 9500.00, '2026-03-20', 'Deposit');

INSERT INTO Shipment (ShipmentID, OrderID, TrackingNumber, ShipDate, DeliveryMethod, ShipmentStatus, ShipmentType, TotalAmount) VALUES
('SHP-2026-0051', 'ORD-2026-00051', 'TRK-0051', '2026-03-28', 'Courier', 'Processing', 'Full', 47500.00);

INSERT INTO ShipmentLine (ShipmentLineID, ShipmentID, OrderID, ItemID, QtyShipped, QtyOutstanding) VALUES
('SHPL-2026-00015', 'SHP-2026-0051', 'ORD-2026-00051', 'IID-P-0003', 1, 0),
('SHPL-2026-00016', 'SHP-2026-0051', 'ORD-2026-00051', 'IID-P-0005', 2, 0);

INSERT INTO DeliveryNote (DeliveryID, ShipmentID, DeliveryDate, Outstanding_qty, ShippingAddress, ShipToName) VALUES
('DN-2026-00051', 'SHP-2026-0051', '2026-03-28', 0,
 '6F Shibuya Scramble Square, 2-24-12 Shibuya, Shibuya-ku, Tokyo 150-6139, Japan', 'Tanaka Home Design');

/*scenario 9: Nordic Nest AB ( payed deposit)*/ 

INSERT INTO Quotation (QuotationID, CustomerID, ExpiryDate, TotalAmount, DepositRequired, LeadTimeEstimated, TermsandCondition, QuotationStatus) VALUES
('QT-2026-0036', 'C-1074', '2026-04-10', 64000.00, 12800.00, '10-14 working days', 'Net 45. Deposit required.', 'Converted');

INSERT INTO `Order` (OrderID, QuotationID, CustomerID, AddressID, SalesID,
                     IssuedTime, DeliveryDate, ShippingAddress, BillingAddress,
                     SubTotal, DiscountType, DiscountValue, DiscountAmount, GrandTotal,
                     OrderContactName, OrderStatus) VALUES
('ORD-2026-00053', 'QT-2026-0036', 'C-1074', 'ADDR-0010', 'S-004',
 '2026-03-25', '2026-04-08',
 'Kungsgatan 55, 111 22 Stockholm, Sweden',
 'Kungsgatan 55, 111 22 Stockholm, Sweden',
 64000.00, 'Amount', 2000.00, 2000.00, 62000.00, 'Erik Lindqvist', 'Pending');

INSERT INTO OrderLine (OrderID, ItemID, Quantity, Price) VALUES
('ORD-2026-00053', 'IID-P-0001', 3, 12800.00),
('ORD-2026-00053', 'IID-P-0002', 2, 8500.00),
('ORD-2026-00053', 'IID-P-0004', 2, 3200.00);

INSERT INTO Invoice (InvoiceID, OrderID, InvoiceDate, DepositAmount, PaidAmount, RemainingBalance, TotalAmount, PaymentStatus, DueDate) VALUES
('INV-2026-00053', 'ORD-2026-00053', '2026-03-25', 12800.00, 12800.00, 49200.00, 62000.00, 'Partial', '2026-04-25');

INSERT INTO `Transaction` (TransactionID, InvoiceID, PurInvoiceID, ReturnID, Amount, TransactionDate, TransactionType) VALUES
('TXN-2026-00014', 'INV-2026-00053', NULL, NULL, 12800.00, '2026-03-25', 'Deposit');

/*scenario 10: Sunrise Interiors (return order)*/

INSERT INTO ReturnOrder (ReturnID, OrderID, ReturnDate, Reason, RefundAmount, ReturnStatus) VALUES
('RTN-2026-0007', 'ORD-2026-00044', '2026-03-09', 'Damaged Goods', 0.00, 'Completed');

INSERT INTO ReturnOrderItem (ReturnItemID, ReturnID, ShipmentLineID, Quantity) VALUES
('RTI-2026-0001', 'RTN-2026-0007', 'SHPL-2026-00010', 1);

/*scenario 11: Chan Siu Ming (return order and refund)*/

INSERT INTO ReturnOrder (ReturnID, OrderID, ReturnDate, Reason, RefundAmount, ReturnStatus) VALUES
('RTN-2026-0006', 'ORD-2026-00033', '2026-03-16', 'Wrong Item Delivered', 8500.00, 'Processing');

INSERT INTO ReturnOrderItem (ReturnItemID, ReturnID, ShipmentLineID, Quantity) VALUES
('RTI-2026-0002', 'RTN-2026-0006', 'SHPL-2026-00002', 1);

INSERT INTO `Transaction` (TransactionID, InvoiceID, PurInvoiceID, ReturnID, Amount, TransactionDate, TransactionType) VALUES
('TXN-2026-00011', NULL, NULL, 'RTN-2026-0006', 8500.00, '2026-03-18', 'Refund');

/*scenario 12: single situation*/

INSERT INTO Quotation (QuotationID, CustomerID, ExpiryDate, TotalAmount, DepositRequired, LeadTimeEstimated, TermsandCondition, QuotationStatus) VALUES
('QT-2026-0033', 'C-1042', '2026-03-24', 30800.00, 6160.00, '5-7 working days', 'Net 30. Full payment upon delivery.', 'Pending');

INSERT INTO `Order` (OrderID, QuotationID, CustomerID, AddressID, SalesID,
                     IssuedTime, DeliveryDate, ShippingAddress, BillingAddress,
                     SubTotal, DiscountType, DiscountValue, DiscountAmount, GrandTotal,
                     OrderContactName, OrderStatus) VALUES
('ORD-2026-00048', NULL,           'C-1018', 'ADDR-0001', 'S-004',
 '2026-03-11', '2026-03-15',
 'Flat 12B, 88 Nathan Road, Tsim Sha Tsui, Kowloon, Hong Kong',
 'Flat 12B, 88 Nathan Road, Tsim Sha Tsui, Kowloon, Hong Kong',
 21300.00, NULL, NULL, 0.00, 21300.00, 'Chan Siu Ming', 'Processing'),

('ORD-2026-00047', NULL,           'C-1022', 'ADDR-0002', 'S-004',
 '2026-03-10', '2026-03-12',
 'Unit 7F, 200 Queens Road West, Sheung Wan, Hong Kong',
 'Unit 7F, 200 Queens Road West, Sheung Wan, Hong Kong',
 29400.00, NULL, NULL, 0.00, 29400.00, 'Lee Wai Kwan', 'Pending'),

('ORD-2026-00046', NULL,           'C-1030', 'ADDR-0003', 'S-004',
 '2026-03-09', '2026-03-18',
 'Unit 3, Meridian Distribution Park, Braunstone, Leicester, LE3 2WX, UK',
 '12th Floor, The Gherkin, 30 St Mary Axe, London, EC3A 8BF, United Kingdom',
 120700.00, NULL, NULL, 0.00, 120700.00, 'ABC Furniture Ltd', 'Pending'),

('ORD-2026-00025', NULL, 'C-1042', 'ADDR-0006', 'S-004',
 '2026-02-20', '2026-03-07',
 '1200 Wilshire Blvd, Suite 800, Los Angeles, CA 90017, USA',
 '1200 Wilshire Blvd, Suite 800, Los Angeles, CA 90017, USA',
 56000.00, NULL, NULL, 0.00, 56000.00, 'Sunrise Interiors', 'Pending');

INSERT INTO OrderLine (OrderID, ItemID, Quantity, Price) VALUES
('ORD-2026-00048', 'IID-P-0001', 1, 12800.00),
('ORD-2026-00048', 'IID-P-0002', 1, 8500.00),
('ORD-2026-00047', 'IID-P-0004', 2, 3200.00),
('ORD-2026-00047', 'IID-P-0005', 1, 14500.00),
('ORD-2026-00047', 'IID-P-0002', 1, 8500.00),
('ORD-2026-00046', 'IID-P-0001', 2, 12800.00),
('ORD-2026-00046', 'IID-P-0003', 1, 18000.00),
('ORD-2026-00046', 'IID-P-0004', 4, 3200.00),
('ORD-2026-00046', 'IID-P-0005', 2, 14500.00),
('ORD-2026-00046', 'IID-P-0002', 1, 8500.00),
('ORD-2026-00025', 'IID-P-0001', 3, 12800.00),
('ORD-2026-00025', 'IID-P-0004', 2, 3200.00);

INSERT INTO Invoice (InvoiceID, OrderID, InvoiceDate, DepositAmount, PaidAmount, RemainingBalance, TotalAmount, PaymentStatus, DueDate) VALUES
('INV-2026-00048', 'ORD-2026-00048', '2026-03-11', 0.00,     0.00,     21300.00, 21300.00, 'Partial', '2026-04-10'),
('INV-2026-00025', 'ORD-2026-00025', '2026-02-20', 11200.00, 11200.00, 44800.00, 56000.00, 'Partial', '2026-03-20');

INSERT INTO `Transaction` (TransactionID, InvoiceID, PurInvoiceID, ReturnID, Amount, TransactionDate, TransactionType) VALUES
('TXN-2026-00007', 'INV-2026-00025', NULL, NULL, 11200.00, '2026-02-20', 'Deposit');

INSERT INTO Shipment (ShipmentID, OrderID, TrackingNumber, ShipDate, DeliveryMethod, ShipmentStatus, ShipmentType, TotalAmount) VALUES
('SHP-2026-0048', 'ORD-2026-00048', 'TRK-0048', '2026-03-16', 'Courier', 'Pending', 'Full', 21300.00);

INSERT INTO ShipmentLine (ShipmentLineID, ShipmentID, OrderID, ItemID, QtyShipped, QtyOutstanding) VALUES
('SHPL-2026-00017', 'SHP-2026-0048', 'ORD-2026-00048', 'IID-P-0001', 1, 0),
('SHPL-2026-00013', 'SHP-2026-0048', 'ORD-2026-00048', 'IID-P-0002', 1, 0);

INSERT INTO DeliveryNote (DeliveryID, ShipmentID, DeliveryDate, Outstanding_qty, ShippingAddress, ShipToName) VALUES
('DN-2026-00048', 'SHP-2026-0048', '2026-03-16', 0,
 'Flat 12B, 88 Nathan Road, Tsim Sha Tsui, Kowloon, Hong Kong', 'Chan Siu Ming');

INSERT INTO Complaint (ComplaintID, OrderID, StaffID, ComplaintDescription, ComplaintStatus) VALUES
('CMP-2026-0015', 'ORD-2026-00048', 'S-004', 'Damaged goods upon delivery',          'Processing'),
('CMP-2026-0014', 'ORD-2026-00047', 'S-003', 'Delayed delivery complaint',           'Completed'),
('CMP-2026-0013', 'ORD-2026-00046', 'S-002', 'Quality issue with product',           'Escalated'),
('CMP-2026-0012', 'ORD-2026-00045', 'S-004', 'Incorrect delivery - wrong item sent', 'Processing'),
('CMP-2026-0006', 'ORD-2026-00025', 'S-004', 'Missing assembly kit in sofa package', 'Pending');

/*scenario 13: Reorder rawmaterial with order*/

INSERT INTO Quotation
  (QuotationID, CustomerID, ExpiryDate, TotalAmount, DepositRequired,
   LeadTimeEstimated, TermsandCondition, QuotationStatus)
VALUES
  ('QT-2026-0040', 'C-1061', '2026-04-01', 91000.00, 18200.00,
   '14-21 working days', 'Net 45. Deposit required upon confirmation.', 'Converted');

INSERT INTO `Order`
  (OrderID, QuotationID, CustomerID, AddressID, SalesID,
   IssuedTime, DeliveryDate, ShippingAddress, BillingAddress,
   SubTotal, DiscountType, DiscountValue, DiscountAmount, GrandTotal,
   OrderContactName, OrderStatus)
VALUES
  ('ORD-2026-00060', 'QT-2026-0040', 'C-1061', 'ADDR-0009', 'S-004',
   '2026-03-18', '2026-04-10',
   '28 Rue du Faubourg Saint-Antoine, 75012 Paris, France',
   '28 Rue du Faubourg Saint-Antoine, 75012 Paris, France',
   91000.00, NULL, NULL, 0.00, 91000.00, 'Beaumont Living SAS', 'Processing');

INSERT INTO OrderLine (OrderID, ItemID, Quantity, Price) VALUES
  ('ORD-2026-00060', 'IID-P-0001', 4, 12800.00),  -- 4x Nordic Sofa
  ('ORD-2026-00060', 'IID-P-0003', 1, 18000.00),  -- 1x Marble Table
  ('ORD-2026-00060', 'IID-P-0005', 2, 14500.00);  -- 2x Wardrobe

INSERT INTO Invoice
  (InvoiceID, OrderID, InvoiceDate, DepositAmount, PaidAmount,
   RemainingBalance, TotalAmount, PaymentStatus, DueDate)
VALUES
  ('INV-2026-00060', 'ORD-2026-00060', '2026-03-18',
   18200.00, 18200.00, 72800.00, 91000.00, 'Partial', '2026-04-18');

INSERT INTO `Transaction`
  (TransactionID, InvoiceID, PurInvoiceID, ReturnID, Amount, TransactionDate, TransactionType)
VALUES
  ('TXN-2026-00015', 'INV-2026-00060', NULL, NULL, 18200.00, '2026-03-18', 'Deposit');

INSERT INTO MaterialRequest
  (RequestID, OrderID, RawMaterialItemID, WarehouseItemID, RequestedQty, UrgencyLevel, TriggerType)
VALUES
  ('MRQ-2026-0024', 'ORD-2026-00060','IID-R-0001', 'WHI-R-0001', 80, 'Critical', 'OrderDemand');

INSERT INTO PurchaseOrder(PurchaseID, RequestID, SupplierID, POTotalAmount, OrderDate, PurchaseStatus)
VALUES ('PO-2026-00025', 'MRQ-2026-0024', 'SUP-2026-0001', 22400.00, '2026-03-19', 'Partially Received');

INSERT INTO PurchaseOrderLine(POLineID, RawMaterialItemID, PurchaseID, WarehouseID, OrderQty, UnitPrice)
VALUES ('POL-2026-0009', 'IID-R-0001', 'PO-2026-00025', 'WH-2026-00002', 80,  280.00);

INSERT INTO PurchaseInvoice(PurInvoiceID, PurchaseID, TotalAmount, PaymentStatus, ExpectedDate)
VALUES ('PURINV-2026-0043', 'PO-2026-00025', 22400.00, 'Partial', '2026-04-19');

 INSERT INTO Receipt(ReceiptID, PurchaseID, POLineID, QtyReceived, ReceiptDate, Outstanding_QTY)
VALUES ('REC-2026-0007', 'PO-2026-00025', 'POL-2026-0009', 40,  '2026-03-26', 40);

INSERT INTO `Transaction`(TransactionID, InvoiceID, PurInvoiceID, ReturnID, Amount, TransactionDate, TransactionType)
VALUES ('TXN-2026-00016', NULL, 'PURINV-2026-0043', NULL, 11200.00, '2026-03-25', 'Installment');