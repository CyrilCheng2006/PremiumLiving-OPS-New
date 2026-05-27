USE PremiumLivingFurniture;

SET @current_staff_id = 'S-001';

DELIMITER $$

DROP TRIGGER IF EXISTS trg_supplier_ai $$
DROP TRIGGER IF EXISTS trg_supplier_au $$
DROP TRIGGER IF EXISTS trg_supplier_ad $$

DROP TRIGGER IF EXISTS trg_staff_ai $$
DROP TRIGGER IF EXISTS trg_staff_au $$
DROP TRIGGER IF EXISTS trg_staff_ad $$

DROP TRIGGER IF EXISTS trg_customer_ai $$
DROP TRIGGER IF EXISTS trg_customer_au $$
DROP TRIGGER IF EXISTS trg_customer_ad $$

DROP TRIGGER IF EXISTS trg_item_ai $$
DROP TRIGGER IF EXISTS trg_item_au $$
DROP TRIGGER IF EXISTS trg_item_ad $$

DROP TRIGGER IF EXISTS trg_rawmaterial_ai $$
DROP TRIGGER IF EXISTS trg_rawmaterial_au $$
DROP TRIGGER IF EXISTS trg_rawmaterial_ad $$

DROP TRIGGER IF EXISTS trg_product_ai $$
DROP TRIGGER IF EXISTS trg_product_au $$
DROP TRIGGER IF EXISTS trg_product_ad $$

DROP TRIGGER IF EXISTS trg_warehouse_ai $$
DROP TRIGGER IF EXISTS trg_warehouse_au $$
DROP TRIGGER IF EXISTS trg_warehouse_ad $$

DROP TRIGGER IF EXISTS trg_address_ai $$
DROP TRIGGER IF EXISTS trg_address_au $$
DROP TRIGGER IF EXISTS trg_address_ad $$

DROP TRIGGER IF EXISTS trg_quotation_ai $$
DROP TRIGGER IF EXISTS trg_quotation_au $$
DROP TRIGGER IF EXISTS trg_quotation_ad $$

DROP TRIGGER IF EXISTS trg_order_ai $$
DROP TRIGGER IF EXISTS trg_order_au $$
DROP TRIGGER IF EXISTS trg_order_ad $$

DROP TRIGGER IF EXISTS trg_orderline_ai $$
DROP TRIGGER IF EXISTS trg_orderline_au $$
DROP TRIGGER IF EXISTS trg_orderline_ad $$

DROP TRIGGER IF EXISTS trg_invoice_ai $$
DROP TRIGGER IF EXISTS trg_invoice_au $$
DROP TRIGGER IF EXISTS trg_invoice_ad $$

DROP TRIGGER IF EXISTS trg_transaction_ai $$
DROP TRIGGER IF EXISTS trg_transaction_au $$
DROP TRIGGER IF EXISTS trg_transaction_ad $$

DROP TRIGGER IF EXISTS trg_transferform_ai $$
DROP TRIGGER IF EXISTS trg_transferform_au $$
DROP TRIGGER IF EXISTS trg_transferform_ad $$

DROP TRIGGER IF EXISTS trg_purchaseorder_ai $$
DROP TRIGGER IF EXISTS trg_purchaseorder_au $$
DROP TRIGGER IF EXISTS trg_purchaseorder_ad $$

DROP TRIGGER IF EXISTS trg_purchaseinvoice_ai $$
DROP TRIGGER IF EXISTS trg_purchaseinvoice_au $$
DROP TRIGGER IF EXISTS trg_purchaseinvoice_ad $$

DROP TRIGGER IF EXISTS trg_purchaseorderline_ai $$
DROP TRIGGER IF EXISTS trg_purchaseorderline_au $$
DROP TRIGGER IF EXISTS trg_purchaseorderline_ad $$

DROP TRIGGER IF EXISTS trg_warehouseitem_ai $$
DROP TRIGGER IF EXISTS trg_warehouseitem_au $$
DROP TRIGGER IF EXISTS trg_warehouseitem_ad $$

DROP TRIGGER IF EXISTS trg_materialrequest_ai $$
DROP TRIGGER IF EXISTS trg_materialrequest_au $$
DROP TRIGGER IF EXISTS trg_materialrequest_ad $$

DROP TRIGGER IF EXISTS trg_receipt_ai $$
DROP TRIGGER IF EXISTS trg_receipt_au $$
DROP TRIGGER IF EXISTS trg_receipt_ad $$

DROP TRIGGER IF EXISTS trg_transferform_whitem_ai $$
DROP TRIGGER IF EXISTS trg_transferform_whitem_au $$
DROP TRIGGER IF EXISTS trg_transferform_whitem_ad $$

DROP TRIGGER IF EXISTS trg_shipment_ai $$
DROP TRIGGER IF EXISTS trg_shipment_au $$
DROP TRIGGER IF EXISTS trg_shipment_ad $$

DROP TRIGGER IF EXISTS trg_shipmentline_ai $$
DROP TRIGGER IF EXISTS trg_shipmentline_au $$
DROP TRIGGER IF EXISTS trg_shipmentline_ad $$

DROP TRIGGER IF EXISTS trg_deliverynote_ai $$
DROP TRIGGER IF EXISTS trg_deliverynote_au $$
DROP TRIGGER IF EXISTS trg_deliverynote_ad $$

DROP TRIGGER IF EXISTS trg_replyslip_ai $$
DROP TRIGGER IF EXISTS trg_replyslip_au $$
DROP TRIGGER IF EXISTS trg_replyslip_ad $$

DROP TRIGGER IF EXISTS trg_returnorder_ai $$
DROP TRIGGER IF EXISTS trg_returnorder_au $$
DROP TRIGGER IF EXISTS trg_returnorder_ad $$

DROP TRIGGER IF EXISTS trg_returnorderitem_ai $$
DROP TRIGGER IF EXISTS trg_returnorderitem_au $$
DROP TRIGGER IF EXISTS trg_returnorderitem_ad $$

DROP TRIGGER IF EXISTS trg_complaint_ai $$
DROP TRIGGER IF EXISTS trg_complaint_au $$
DROP TRIGGER IF EXISTS trg_complaint_ad $$

/* Supplier */

CREATE TRIGGER trg_supplier_ai
AFTER INSERT ON Supplier
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'Supplier',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'SupplierID', NEW.SupplierID,
            'PhoneNumber', NEW.PhoneNumber,
            'SupplierAddress', NEW.SupplierAddress,
            'SupplierName', NEW.SupplierName
        )
    );
END $$

CREATE TRIGGER trg_supplier_au
AFTER UPDATE ON Supplier
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.SupplierID <=> NEW.SupplierID AND
        OLD.PhoneNumber <=> NEW.PhoneNumber AND
        OLD.SupplierAddress <=> NEW.SupplierAddress AND
        OLD.SupplierName <=> NEW.SupplierName
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'Supplier',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'SupplierID', OLD.SupplierID,
                'PhoneNumber', OLD.PhoneNumber,
                'SupplierAddress', OLD.SupplierAddress,
                'SupplierName', OLD.SupplierName
            ),
            JSON_OBJECT(
                'SupplierID', NEW.SupplierID,
                'PhoneNumber', NEW.PhoneNumber,
                'SupplierAddress', NEW.SupplierAddress,
                'SupplierName', NEW.SupplierName
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_supplier_ad
AFTER DELETE ON Supplier
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'Supplier',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'SupplierID', OLD.SupplierID,
            'PhoneNumber', OLD.PhoneNumber,
            'SupplierAddress', OLD.SupplierAddress,
            'SupplierName', OLD.SupplierName
        ),
        NULL
    );
END $$

/* Staff */

CREATE TRIGGER trg_staff_ai
AFTER INSERT ON Staff
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        COALESCE(@current_staff_id, NEW.StaffID),
        'Create',
        'Staff',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'StaffID', NEW.StaffID,
            'StaffName', NEW.StaffName,
            'StaffRole', NEW.StaffRole,
            'Email', NEW.Email,
            'StaffPassword', NEW.StaffPassword,
            'Department', NEW.Department
        )
    );
END $$

CREATE TRIGGER trg_staff_au
AFTER UPDATE ON Staff
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.StaffID <=> NEW.StaffID AND
        OLD.StaffName <=> NEW.StaffName AND
        OLD.StaffRole <=> NEW.StaffRole AND
        OLD.Email <=> NEW.Email AND
        OLD.StaffPassword <=> NEW.StaffPassword AND
        OLD.Department <=> NEW.Department
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            COALESCE(@current_staff_id, NEW.StaffID, OLD.StaffID),
            'Edit',
            'Staff',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'StaffID', OLD.StaffID,
                'StaffName', OLD.StaffName,
                'StaffRole', OLD.StaffRole,
                'Email', OLD.Email,
                'StaffPassword', OLD.StaffPassword,
                'Department', OLD.Department
            ),
            JSON_OBJECT(
                'StaffID', NEW.StaffID,
                'StaffName', NEW.StaffName,
                'StaffRole', NEW.StaffRole,
                'Email', NEW.Email,
                'StaffPassword', NEW.StaffPassword,
                'Department', NEW.Department
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_staff_ad
AFTER DELETE ON Staff
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        COALESCE(@current_staff_id, OLD.StaffID),
        'Delete',
        'Staff',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'StaffID', OLD.StaffID,
            'StaffName', OLD.StaffName,
            'StaffRole', OLD.StaffRole,
            'Email', OLD.Email,
            'StaffPassword', OLD.StaffPassword,
            'Department', OLD.Department
        ),
        NULL
    );
END $$


/* Customer */
CREATE TRIGGER trg_customer_ai
AFTER INSERT ON Customer
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'Customer',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'CustomerID', NEW.CustomerID,
            'CustomerName', NEW.CustomerName,
            'EmailAddress', NEW.EmailAddress,
            'PhoneNumber', NEW.PhoneNumber
        )
    );
END $$

CREATE TRIGGER trg_customer_au
AFTER UPDATE ON Customer
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.CustomerID <=> NEW.CustomerID AND
        OLD.CustomerName <=> NEW.CustomerName AND
        OLD.EmailAddress <=> NEW.EmailAddress AND
        OLD.PhoneNumber <=> NEW.PhoneNumber
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'Customer',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'CustomerID', OLD.CustomerID,
                'CustomerName', OLD.CustomerName,
                'EmailAddress', OLD.EmailAddress,
                'PhoneNumber', OLD.PhoneNumber
            ),
            JSON_OBJECT(
                'CustomerID', NEW.CustomerID,
                'CustomerName', NEW.CustomerName,
                'EmailAddress', NEW.EmailAddress,
                'PhoneNumber', NEW.PhoneNumber
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_customer_ad
AFTER DELETE ON Customer
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'Customer',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'CustomerID', OLD.CustomerID,
            'CustomerName', OLD.CustomerName,
            'EmailAddress', OLD.EmailAddress,
            'PhoneNumber', OLD.PhoneNumber
        ),
        NULL
    );
END $$



/* Item */

CREATE TRIGGER trg_item_ai
AFTER INSERT ON Item
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'Item',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'ItemID', NEW.ItemID,
            'ItemName', NEW.ItemName,
            'ItemDescription', NEW.ItemDescription
        )
    );
END $$

CREATE TRIGGER trg_item_au
AFTER UPDATE ON Item
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.ItemID <=> NEW.ItemID AND
        OLD.ItemName <=> NEW.ItemName AND
        OLD.ItemDescription <=> NEW.ItemDescription
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'Item',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'ItemID', OLD.ItemID,
                'ItemName', OLD.ItemName,
                'ItemDescription', OLD.ItemDescription
            ),
            JSON_OBJECT(
                'ItemID', NEW.ItemID,
                'ItemName', NEW.ItemName,
                'ItemDescription', NEW.ItemDescription
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_item_ad
AFTER DELETE ON Item
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'Item',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'ItemID', OLD.ItemID,
            'ItemName', OLD.ItemName,
            'ItemDescription', OLD.ItemDescription
        ),
        NULL
    );
END $$


/* RawMaterial */

CREATE TRIGGER trg_rawmaterial_ai
AFTER INSERT ON RawMaterial
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'RawMaterial',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'ItemID', NEW.ItemID,
            'purchasePrice', NEW.purchasePrice,
            'MaterialType', NEW.MaterialType
        )
    );
END $$

CREATE TRIGGER trg_rawmaterial_au
AFTER UPDATE ON RawMaterial
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.ItemID <=> NEW.ItemID AND
        OLD.purchasePrice <=> NEW.purchasePrice AND
        OLD.MaterialType <=> NEW.MaterialType
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'RawMaterial',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'ItemID', OLD.ItemID,
                'purchasePrice', OLD.purchasePrice,
                'MaterialType', OLD.MaterialType
            ),
            JSON_OBJECT(
                'ItemID', NEW.ItemID,
                'purchasePrice', NEW.purchasePrice,
                'MaterialType', NEW.MaterialType
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_rawmaterial_ad
AFTER DELETE ON RawMaterial
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'RawMaterial',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'ItemID', OLD.ItemID,
            'purchasePrice', OLD.purchasePrice,
            'MaterialType', OLD.MaterialType
        ),
        NULL
    );
END $$

/* Product */

CREATE TRIGGER trg_product_ai
AFTER INSERT ON Product
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'Product',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'ItemID', NEW.ItemID,
            'SalesPrice', NEW.SalesPrice,
            'Category', NEW.Category
        )
    );
END $$

CREATE TRIGGER trg_product_au
AFTER UPDATE ON Product
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.ItemID <=> NEW.ItemID AND
        OLD.SalesPrice <=> NEW.SalesPrice AND
        OLD.Category <=> NEW.Category
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'Product',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'ItemID', OLD.ItemID,
                'SalesPrice', OLD.SalesPrice,
                'Category', OLD.Category
            ),
            JSON_OBJECT(
                'ItemID', NEW.ItemID,
                'SalesPrice', NEW.SalesPrice,
                'Category', NEW.Category
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_product_ad
AFTER DELETE ON Product
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'Product',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'ItemID', OLD.ItemID,
            'SalesPrice', OLD.SalesPrice,
            'Category', OLD.Category
        ),
        NULL
    );
END $$


/* Warehouse */

CREATE TRIGGER trg_warehouse_ai
AFTER INSERT ON Warehouse
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        COALESCE(NEW.ManagerID, @current_staff_id),
        'Create',
        'Warehouse',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'WarehouseID', NEW.WarehouseID,
            'ManagerID', NEW.ManagerID,
            'WarehouseLocation', NEW.WarehouseLocation,
            'ContactNumber', NEW.ContactNumber,
            'Capacity', NEW.Capacity
        )
    );
END $$

CREATE TRIGGER trg_warehouse_au
AFTER UPDATE ON Warehouse
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.WarehouseID <=> NEW.WarehouseID AND
        OLD.ManagerID <=> NEW.ManagerID AND
        OLD.WarehouseLocation <=> NEW.WarehouseLocation AND
        OLD.ContactNumber <=> NEW.ContactNumber AND
        OLD.Capacity <=> NEW.Capacity
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            COALESCE(NEW.ManagerID, OLD.ManagerID, @current_staff_id),
            'Edit',
            'Warehouse',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'WarehouseID', OLD.WarehouseID,
                'ManagerID', OLD.ManagerID,
                'WarehouseLocation', OLD.WarehouseLocation,
                'ContactNumber', OLD.ContactNumber,
                'Capacity', OLD.Capacity
            ),
            JSON_OBJECT(
                'WarehouseID', NEW.WarehouseID,
                'ManagerID', NEW.ManagerID,
                'WarehouseLocation', NEW.WarehouseLocation,
                'ContactNumber', NEW.ContactNumber,
                'Capacity', NEW.Capacity
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_warehouse_ad
AFTER DELETE ON Warehouse
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        COALESCE(OLD.ManagerID, @current_staff_id),
        'Delete',
        'Warehouse',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'WarehouseID', OLD.WarehouseID,
            'ManagerID', OLD.ManagerID,
            'WarehouseLocation', OLD.WarehouseLocation,
            'ContactNumber', OLD.ContactNumber,
            'Capacity', OLD.Capacity
        ),
        NULL
    );
END $$

/* Address */

CREATE TRIGGER trg_address_ai
AFTER INSERT ON Address
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'Address',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'AddressID', NEW.AddressID,
            'CustomerID', NEW.CustomerID,
            'AddressName', NEW.AddressName,
            'AddressType', NEW.AddressType,
            'isDefault', NEW.isDefault
        )
    );
END $$

CREATE TRIGGER trg_address_au
AFTER UPDATE ON Address
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.AddressID <=> NEW.AddressID AND
        OLD.CustomerID <=> NEW.CustomerID AND
        OLD.AddressName <=> NEW.AddressName AND
        OLD.AddressType <=> NEW.AddressType AND
        OLD.isDefault <=> NEW.isDefault
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'Address',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'AddressID', OLD.AddressID,
                'CustomerID', OLD.CustomerID,
                'AddressName', OLD.AddressName,
                'AddressType', OLD.AddressType,
                'isDefault', OLD.isDefault
            ),
            JSON_OBJECT(
                'AddressID', NEW.AddressID,
                'CustomerID', NEW.CustomerID,
                'AddressName', NEW.AddressName,
                'AddressType', NEW.AddressType,
                'isDefault', NEW.isDefault
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_address_ad
AFTER DELETE ON Address
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'Address',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'AddressID', OLD.AddressID,
            'CustomerID', OLD.CustomerID,
            'AddressName', OLD.AddressName,
            'AddressType', OLD.AddressType,
            'isDefault', OLD.isDefault
        ),
        NULL
    );
END $$

/* Quotation */

CREATE TRIGGER trg_quotation_ai
AFTER INSERT ON Quotation
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'Quotation',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'QuotationID', NEW.QuotationID,
            'CustomerID', NEW.CustomerID,
            'ExpiryDate', NEW.ExpiryDate,
            'DepositRequired', NEW.DepositRequired,
            'TotalAmount', NEW.TotalAmount,
            'LeadTimeEstimated', NEW.LeadTimeEstimated,
            'TermsandCondition', NEW.TermsandCondition,
            'QuotationStatus', NEW.QuotationStatus
        )
    );
END $$

CREATE TRIGGER trg_quotation_au
AFTER UPDATE ON Quotation
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.QuotationID <=> NEW.QuotationID AND
        OLD.CustomerID <=> NEW.CustomerID AND
        OLD.ExpiryDate <=> NEW.ExpiryDate AND
        OLD.DepositRequired <=> NEW.DepositRequired AND
        OLD.TotalAmount <=> NEW.TotalAmount AND
        OLD.LeadTimeEstimated <=> NEW.LeadTimeEstimated AND
        OLD.TermsandCondition <=> NEW.TermsandCondition AND
        OLD.QuotationStatus <=> NEW.QuotationStatus
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'Quotation',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'QuotationID', OLD.QuotationID,
                'CustomerID', OLD.CustomerID,
                'ExpiryDate', OLD.ExpiryDate,
                'DepositRequired', OLD.DepositRequired,
                'TotalAmount', OLD.TotalAmount,
                'LeadTimeEstimated', OLD.LeadTimeEstimated,
                'TermsandCondition', OLD.TermsandCondition,
                'QuotationStatus', OLD.QuotationStatus
            ),
            JSON_OBJECT(
                'QuotationID', NEW.QuotationID,
                'CustomerID', NEW.CustomerID,
                'ExpiryDate', NEW.ExpiryDate,
                'DepositRequired', NEW.DepositRequired,
                'TotalAmount', NEW.TotalAmount,
                'LeadTimeEstimated', NEW.LeadTimeEstimated,
                'TermsandCondition', NEW.TermsandCondition,
                'QuotationStatus', NEW.QuotationStatus
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_quotation_ad
AFTER DELETE ON Quotation
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'Quotation',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'QuotationID', OLD.QuotationID,
            'CustomerID', OLD.CustomerID,
            'ExpiryDate', OLD.ExpiryDate,
            'DepositRequired', OLD.DepositRequired,
            'TotalAmount', OLD.TotalAmount,
            'LeadTimeEstimated', OLD.LeadTimeEstimated,
            'TermsandCondition', OLD.TermsandCondition,
            'QuotationStatus', OLD.QuotationStatus
        ),
        NULL
    );
END $$


/* Order */

CREATE TRIGGER trg_order_ai
AFTER INSERT ON `Order`
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        COALESCE(NEW.SalesID, @current_staff_id),
        'Create',
        'Order',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'OrderID', NEW.OrderID,
            'QuotationID', NEW.QuotationID,
            'CustomerID', NEW.CustomerID,
            'AddressID', NEW.AddressID,
            'SalesID', NEW.SalesID,
            'IssuedTime', NEW.IssuedTime,
            'DeliveryDate', NEW.DeliveryDate,
            'ShippingAddress', NEW.ShippingAddress,
            'BillingAddress', NEW.BillingAddress,
            'SubTotal', NEW.SubTotal,
            'DiscountType', NEW.DiscountType,
            'DiscountValue', NEW.DiscountValue,
            'DiscountAmount', NEW.DiscountAmount,
            'GrandTotal', NEW.GrandTotal,
            'OrderContactName', NEW.OrderContactName,
            'OrderStatus', NEW.OrderStatus
        )
    );
END $$

CREATE TRIGGER trg_order_au
AFTER UPDATE ON `Order`
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.OrderID <=> NEW.OrderID AND
        OLD.QuotationID <=> NEW.QuotationID AND
        OLD.CustomerID <=> NEW.CustomerID AND
        OLD.AddressID <=> NEW.AddressID AND
        OLD.SalesID <=> NEW.SalesID AND
        OLD.IssuedTime <=> NEW.IssuedTime AND
        OLD.DeliveryDate <=> NEW.DeliveryDate AND
        OLD.ShippingAddress <=> NEW.ShippingAddress AND
        OLD.BillingAddress <=> NEW.BillingAddress AND
        OLD.SubTotal <=> NEW.SubTotal AND
        OLD.DiscountType <=> NEW.DiscountType AND
        OLD.DiscountValue <=> NEW.DiscountValue AND
        OLD.DiscountAmount <=> NEW.DiscountAmount AND
        OLD.GrandTotal <=> NEW.GrandTotal AND
        OLD.OrderContactName <=> NEW.OrderContactName AND
        OLD.OrderStatus <=> NEW.OrderStatus
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            COALESCE(NEW.SalesID, OLD.SalesID, @current_staff_id),
            'Edit',
            'Order',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'OrderID', OLD.OrderID,
                'QuotationID', OLD.QuotationID,
                'CustomerID', OLD.CustomerID,
                'AddressID', OLD.AddressID,
                'SalesID', OLD.SalesID,
                'IssuedTime', OLD.IssuedTime,
                'DeliveryDate', OLD.DeliveryDate,
                'ShippingAddress', OLD.ShippingAddress,
                'BillingAddress', OLD.BillingAddress,
                'SubTotal', OLD.SubTotal,
                'DiscountType', OLD.DiscountType,
                'DiscountValue', OLD.DiscountValue,
                'DiscountAmount', OLD.DiscountAmount,
                'GrandTotal', OLD.GrandTotal,
                'OrderContactName', OLD.OrderContactName,
                'OrderStatus', OLD.OrderStatus
            ),
            JSON_OBJECT(
                'OrderID', NEW.OrderID,
                'QuotationID', NEW.QuotationID,
                'CustomerID', NEW.CustomerID,
                'AddressID', NEW.AddressID,
                'SalesID', NEW.SalesID,
                'IssuedTime', NEW.IssuedTime,
                'DeliveryDate', NEW.DeliveryDate,
                'ShippingAddress', NEW.ShippingAddress,
                'BillingAddress', NEW.BillingAddress,
                'SubTotal', NEW.SubTotal,
                'DiscountType', NEW.DiscountType,
                'DiscountValue', NEW.DiscountValue,
                'DiscountAmount', NEW.DiscountAmount,
                'GrandTotal', NEW.GrandTotal,
                'OrderContactName', NEW.OrderContactName,
                'OrderStatus', NEW.OrderStatus
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_order_ad
AFTER DELETE ON `Order`
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        COALESCE(OLD.SalesID, @current_staff_id),
        'Delete',
        'Order',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'OrderID', OLD.OrderID,
            'QuotationID', OLD.QuotationID,
            'CustomerID', OLD.CustomerID,
            'AddressID', OLD.AddressID,
            'SalesID', OLD.SalesID,
            'IssuedTime', OLD.IssuedTime,
            'DeliveryDate', OLD.DeliveryDate,
            'ShippingAddress', OLD.ShippingAddress,
            'BillingAddress', OLD.BillingAddress,
            'SubTotal', OLD.SubTotal,
            'DiscountType', OLD.DiscountType,
            'DiscountValue', OLD.DiscountValue,
            'DiscountAmount', OLD.DiscountAmount,
            'GrandTotal', OLD.GrandTotal,
            'OrderContactName', OLD.OrderContactName,
            'OrderStatus', OLD.OrderStatus
        ),
        NULL
    );
END $$


/* OrderLine */

CREATE TRIGGER trg_orderline_ai
AFTER INSERT ON OrderLine
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (UUID(), @current_staff_id, 'Create', 'OrderLine', CURRENT_TIMESTAMP, NULL,
        JSON_OBJECT(
            'OrderID', NEW.OrderID,
            'ItemID', NEW.ItemID,
            'Quantity', NEW.Quantity,
            'Price', NEW.Price
        )
    );
END $$

CREATE TRIGGER trg_orderline_au
AFTER UPDATE ON OrderLine
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.OrderID <=> NEW.OrderID AND
        OLD.ItemID <=> NEW.ItemID AND
        OLD.Quantity <=> NEW.Quantity AND
        OLD.Price <=> NEW.Price
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (UUID(), @current_staff_id, 'Edit', 'OrderLine', CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'OrderID', OLD.OrderID,
                'ItemID', OLD.ItemID,
                'Quantity', OLD.Quantity,
                'Price', OLD.Price
            ),
            JSON_OBJECT(
                'OrderID', NEW.OrderID,
                'ItemID', NEW.ItemID,
                'Quantity', NEW.Quantity,
                'Price', NEW.Price
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_orderline_ad
AFTER DELETE ON OrderLine
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (UUID(), @current_staff_id, 'Delete', 'OrderLine', CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'OrderID', OLD.OrderID,
            'ItemID', OLD.ItemID,
            'Quantity', OLD.Quantity,
            'Price', OLD.Price
        ),
        NULL
    );
END $$



/* Invoice */

CREATE TRIGGER trg_invoice_ai
AFTER INSERT ON Invoice
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'Invoice',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'InvoiceID', NEW.InvoiceID,
            'OrderID', NEW.OrderID,
            'InvoiceDate', NEW.InvoiceDate,
            'DepositAmount', NEW.DepositAmount,
            'PaidAmount', NEW.PaidAmount,
            'RemainingBalance', NEW.RemainingBalance,
            'TotalAmount', NEW.TotalAmount,
            'PaymentStatus', NEW.PaymentStatus,
            'DueDate', NEW.DueDate
        )
    );
END $$

CREATE TRIGGER trg_invoice_au
AFTER UPDATE ON Invoice
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.InvoiceID <=> NEW.InvoiceID AND
        OLD.OrderID <=> NEW.OrderID AND
        OLD.InvoiceDate <=> NEW.InvoiceDate AND
        OLD.DepositAmount <=> NEW.DepositAmount AND
        OLD.PaidAmount <=> NEW.PaidAmount AND
        OLD.RemainingBalance <=> NEW.RemainingBalance AND
        OLD.TotalAmount <=> NEW.TotalAmount AND
        OLD.PaymentStatus <=> NEW.PaymentStatus AND
        OLD.DueDate <=> NEW.DueDate
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'Invoice',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'InvoiceID', OLD.InvoiceID,
                'OrderID', OLD.OrderID,
                'InvoiceDate', OLD.InvoiceDate,
                'DepositAmount', OLD.DepositAmount,
                'PaidAmount', OLD.PaidAmount,
                'RemainingBalance', OLD.RemainingBalance,
                'TotalAmount', OLD.TotalAmount,
                'PaymentStatus', OLD.PaymentStatus,
                'DueDate', OLD.DueDate
            ),
            JSON_OBJECT(
                'InvoiceID', NEW.InvoiceID,
                'OrderID', NEW.OrderID,
                'InvoiceDate', NEW.InvoiceDate,
                'DepositAmount', NEW.DepositAmount,
                'PaidAmount', NEW.PaidAmount,
                'RemainingBalance', NEW.RemainingBalance,
                'TotalAmount', NEW.TotalAmount,
                'PaymentStatus', NEW.PaymentStatus,
                'DueDate', NEW.DueDate
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_invoice_ad
AFTER DELETE ON Invoice
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'Invoice',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'InvoiceID', OLD.InvoiceID,
            'OrderID', OLD.OrderID,
            'InvoiceDate', OLD.InvoiceDate,
            'DepositAmount', OLD.DepositAmount,
            'PaidAmount', OLD.PaidAmount,
            'RemainingBalance', OLD.RemainingBalance,
            'TotalAmount', OLD.TotalAmount,
            'PaymentStatus', OLD.PaymentStatus,
            'DueDate', OLD.DueDate
        ),
        NULL
    );
END $$


/* Transaction */

CREATE TRIGGER trg_transaction_ai
AFTER INSERT ON `Transaction`
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'Transaction',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'TransactionID', NEW.TransactionID,
            'InvoiceID', NEW.InvoiceID,
            'PurInvoiceID', NEW.PurInvoiceID,
            'ReturnID', NEW.ReturnID,
            'Amount', NEW.Amount,
            'TransactionDate', NEW.TransactionDate,
            'TransactionType', NEW.TransactionType
        )
    );
END $$

CREATE TRIGGER trg_transaction_au
AFTER UPDATE ON `Transaction`
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.TransactionID <=> NEW.TransactionID AND
        OLD.InvoiceID <=> NEW.InvoiceID AND
        OLD.PurInvoiceID <=> NEW.PurInvoiceID AND
        OLD.ReturnID <=> NEW.ReturnID AND
        OLD.Amount <=> NEW.Amount AND
        OLD.TransactionDate <=> NEW.TransactionDate AND
        OLD.TransactionType <=> NEW.TransactionType
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'Transaction',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'TransactionID', OLD.TransactionID,
                'InvoiceID', OLD.InvoiceID,
                'PurInvoiceID', OLD.PurInvoiceID,
                'ReturnID', OLD.ReturnID,
                'Amount', OLD.Amount,
                'TransactionDate', OLD.TransactionDate,
                'TransactionType', OLD.TransactionType
            ),
            JSON_OBJECT(
                'TransactionID', NEW.TransactionID,
                'InvoiceID', NEW.InvoiceID,
                'PurInvoiceID', NEW.PurInvoiceID,
                'ReturnID', NEW.ReturnID,
                'Amount', NEW.Amount,
                'TransactionDate', NEW.TransactionDate,
                'TransactionType', NEW.TransactionType
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_transaction_ad
AFTER DELETE ON `Transaction`
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'Transaction',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'TransactionID', OLD.TransactionID,
            'InvoiceID', OLD.InvoiceID,
            'PurInvoiceID', OLD.PurInvoiceID,
            'ReturnID', OLD.ReturnID,
            'Amount', OLD.Amount,
            'TransactionDate', OLD.TransactionDate,
            'TransactionType', OLD.TransactionType
        ),
        NULL
    );
END $$

/* TransferForm */

CREATE TRIGGER trg_transferform_ai
AFTER INSERT ON TransferForm
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (UUID(), @current_staff_id, 'Create', 'TransferForm', CURRENT_TIMESTAMP, NULL,
        JSON_OBJECT(
            'TransferID', NEW.TransferID,
            'TransferDate', NEW.TransferDate,
            'TransferStatus', NEW.TransferStatus
        )
    );
END $$

CREATE TRIGGER trg_transferform_au
AFTER UPDATE ON TransferForm
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.TransferID <=> NEW.TransferID AND
        OLD.TransferDate <=> NEW.TransferDate AND
        OLD.TransferStatus <=> NEW.TransferStatus
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (UUID(), @current_staff_id, 'Edit', 'TransferForm', CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'TransferID', OLD.TransferID,
                'TransferDate', OLD.TransferDate,
                'TransferStatus', OLD.TransferStatus
            ),
            JSON_OBJECT(
                'TransferID', NEW.TransferID,
                'TransferDate', NEW.TransferDate,
                'TransferStatus', NEW.TransferStatus
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_transferform_ad
AFTER DELETE ON TransferForm
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (UUID(), @current_staff_id, 'Delete', 'TransferForm', CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'TransferID', OLD.TransferID,
            'TransferDate', OLD.TransferDate,
            'TransferStatus', OLD.TransferStatus
        ),
        NULL
    );
END $$


/* PurchaseOrder */

CREATE TRIGGER trg_purchaseorder_ai
AFTER INSERT ON PurchaseOrder
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'PurchaseOrder',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'PurchaseID', NEW.PurchaseID,
            'RequestID', NEW.RequestID,
            'SupplierID', NEW.SupplierID,
            'POTotalAmount', NEW.POTotalAmount,
            'OrderDate', NEW.OrderDate,
            'PurchaseStatus', NEW.PurchaseStatus
        )
    );
END $$

CREATE TRIGGER trg_purchaseorder_au
AFTER UPDATE ON PurchaseOrder
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.PurchaseID <=> NEW.PurchaseID AND
        OLD.RequestID <=> NEW.RequestID AND
        OLD.SupplierID <=> NEW.SupplierID AND
        OLD.POTotalAmount <=> NEW.POTotalAmount AND
        OLD.OrderDate <=> NEW.OrderDate AND
        OLD.PurchaseStatus <=> NEW.PurchaseStatus
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'PurchaseOrder',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'PurchaseID', OLD.PurchaseID,
                'RequestID', OLD.RequestID,
                'SupplierID', OLD.SupplierID,
                'POTotalAmount', OLD.POTotalAmount,
                'OrderDate', OLD.OrderDate,
                'PurchaseStatus', OLD.PurchaseStatus
            ),
            JSON_OBJECT(
                'PurchaseID', NEW.PurchaseID,
                'RequestID', NEW.RequestID,
                'SupplierID', NEW.SupplierID,
                'POTotalAmount', NEW.POTotalAmount,
                'OrderDate', NEW.OrderDate,
                'PurchaseStatus', NEW.PurchaseStatus
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_purchaseorder_ad
AFTER DELETE ON PurchaseOrder
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'PurchaseOrder',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'PurchaseID', OLD.PurchaseID,
            'RequestID', OLD.RequestID,
            'SupplierID', OLD.SupplierID,
            'POTotalAmount', OLD.POTotalAmount,
            'OrderDate', OLD.OrderDate,
            'PurchaseStatus', OLD.PurchaseStatus
        ),
        NULL
    );
END $$


/* PurchaseInvoice */

CREATE TRIGGER trg_purchaseinvoice_ai
AFTER INSERT ON PurchaseInvoice
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'PurchaseInvoice',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'PurInvoiceID', NEW.PurInvoiceID,
            'PurchaseID', NEW.PurchaseID,
            'TotalAmount', NEW.TotalAmount,
            'PaymentStatus', NEW.PaymentStatus,
            'ExpectedDate', NEW.ExpectedDate
        )
    );
END $$

CREATE TRIGGER trg_purchaseinvoice_au
AFTER UPDATE ON PurchaseInvoice
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.PurInvoiceID <=> NEW.PurInvoiceID AND
        OLD.PurchaseID <=> NEW.PurchaseID AND
        OLD.TotalAmount <=> NEW.TotalAmount AND
        OLD.PaymentStatus <=> NEW.PaymentStatus AND
        OLD.ExpectedDate <=> NEW.ExpectedDate
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'PurchaseInvoice',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'PurInvoiceID', OLD.PurInvoiceID,
                'PurchaseID', OLD.PurchaseID,
                'TotalAmount', OLD.TotalAmount,
                'PaymentStatus', OLD.PaymentStatus,
                'ExpectedDate', OLD.ExpectedDate
            ),
            JSON_OBJECT(
                'PurInvoiceID', NEW.PurInvoiceID,
                'PurchaseID', NEW.PurchaseID,
                'TotalAmount', NEW.TotalAmount,
                'PaymentStatus', NEW.PaymentStatus,
                'ExpectedDate', NEW.ExpectedDate
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_purchaseinvoice_ad
AFTER DELETE ON PurchaseInvoice
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'PurchaseInvoice',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'PurInvoiceID', OLD.PurInvoiceID,
            'PurchaseID', OLD.PurchaseID,
            'TotalAmount', OLD.TotalAmount,
            'PaymentStatus', OLD.PaymentStatus,
            'ExpectedDate', OLD.ExpectedDate
        ),
        NULL
    );
END $$


/* PurchaseOrderLine */

CREATE TRIGGER trg_purchaseorderline_ai
AFTER INSERT ON PurchaseOrderLine
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'PurchaseOrderLine',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'POLineID', NEW.POLineID,
            'RawMaterialItemID', NEW.RawMaterialItemID,
            'PurchaseID', NEW.PurchaseID,
            'WarehouseID', NEW.WarehouseID,
            'OrderQty', NEW.OrderQty,
            'UnitPrice', NEW.UnitPrice
        )
    );
END $$

CREATE TRIGGER trg_purchaseorderline_au
AFTER UPDATE ON PurchaseOrderLine
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.POLineID <=> NEW.POLineID AND
        OLD.RawMaterialItemID <=> NEW.RawMaterialItemID AND
        OLD.PurchaseID <=> NEW.PurchaseID AND
        OLD.WarehouseID <=> NEW.WarehouseID AND
        OLD.OrderQty <=> NEW.OrderQty AND
        OLD.UnitPrice <=> NEW.UnitPrice
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'PurchaseOrderLine',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'POLineID', OLD.POLineID,
                'RawMaterialItemID', OLD.RawMaterialItemID,
                'PurchaseID', OLD.PurchaseID,
                'WarehouseID', OLD.WarehouseID,
                'OrderQty', OLD.OrderQty,
                'UnitPrice', OLD.UnitPrice
            ),
            JSON_OBJECT(
                'POLineID', NEW.POLineID,
                'RawMaterialItemID', NEW.RawMaterialItemID,
                'PurchaseID', NEW.PurchaseID,
                'WarehouseID', NEW.WarehouseID,
                'OrderQty', NEW.OrderQty,
                'UnitPrice', NEW.UnitPrice
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_purchaseorderline_ad
AFTER DELETE ON PurchaseOrderLine
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'PurchaseOrderLine',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'POLineID', OLD.POLineID,
            'RawMaterialItemID', OLD.RawMaterialItemID,
            'PurchaseID', OLD.PurchaseID,
            'WarehouseID', OLD.WarehouseID,
            'OrderQty', OLD.OrderQty,
            'UnitPrice', OLD.UnitPrice
        ),
        NULL
    );
END $$


/* WarehouseItem */

CREATE TRIGGER trg_warehouseitem_ai
AFTER INSERT ON WarehouseItem
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'WarehouseItem',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'WarehouseItemID', NEW.WarehouseItemID,
            'ItemID', NEW.ItemID,
            'WarehouseID', NEW.WarehouseID,
            'WarehouseItemQuantity', NEW.WarehouseItemQuantity,
            'ReorderLevel', NEW.ReorderLevel
        )
    );
END $$

CREATE TRIGGER trg_warehouseitem_au
AFTER UPDATE ON WarehouseItem
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.WarehouseItemID <=> NEW.WarehouseItemID AND
        OLD.ItemID <=> NEW.ItemID AND
        OLD.WarehouseID <=> NEW.WarehouseID AND
        OLD.WarehouseItemQuantity <=> NEW.WarehouseItemQuantity AND
        OLD.ReorderLevel <=> NEW.ReorderLevel
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'WarehouseItem',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'WarehouseItemID', OLD.WarehouseItemID,
                'ItemID', OLD.ItemID,
                'WarehouseID', OLD.WarehouseID,
                'WarehouseItemQuantity', OLD.WarehouseItemQuantity,
                'ReorderLevel', OLD.ReorderLevel
            ),
            JSON_OBJECT(
                'WarehouseItemID', NEW.WarehouseItemID,
                'ItemID', NEW.ItemID,
                'WarehouseID', NEW.WarehouseID,
                'WarehouseItemQuantity', NEW.WarehouseItemQuantity,
                'ReorderLevel', NEW.ReorderLevel
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_warehouseitem_ad
AFTER DELETE ON WarehouseItem
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'WarehouseItem',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'WarehouseItemID', OLD.WarehouseItemID,
            'ItemID', OLD.ItemID,
            'WarehouseID', OLD.WarehouseID,
            'WarehouseItemQuantity', OLD.WarehouseItemQuantity,
            'ReorderLevel', OLD.ReorderLevel
        ),
        NULL
    );
END $$

/* MaterialRequest */

CREATE TRIGGER trg_materialrequest_ai
AFTER INSERT ON MaterialRequest
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'MaterialRequest',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'RequestID', NEW.RequestID,
            'OrderID', NEW.OrderID,
            'RawMaterialItemID', NEW.RawMaterialItemID,
            'WarehouseItemID', NEW.WarehouseItemID,
            'RequestedQty', NEW.RequestedQty,
            'UrgencyLevel', NEW.UrgencyLevel,
            'TriggerType', NEW.TriggerType
        )
    );
END $$

CREATE TRIGGER trg_materialrequest_au
AFTER UPDATE ON MaterialRequest
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.RequestID <=> NEW.RequestID AND
        OLD.OrderID <=> NEW.OrderID AND
        OLD.RawMaterialItemID <=> NEW.RawMaterialItemID AND
        OLD.WarehouseItemID <=> NEW.WarehouseItemID AND
        OLD.RequestedQty <=> NEW.RequestedQty AND
        OLD.UrgencyLevel <=> NEW.UrgencyLevel AND
        OLD.TriggerType <=> NEW.TriggerType
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'MaterialRequest',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'RequestID', OLD.RequestID,
                'OrderID', OLD.OrderID,
                'RawMaterialItemID', OLD.RawMaterialItemID,
                'WarehouseItemID', OLD.WarehouseItemID,
                'RequestedQty', OLD.RequestedQty,
                'UrgencyLevel', OLD.UrgencyLevel,
                'TriggerType', OLD.TriggerType
            ),
            JSON_OBJECT(
                'RequestID', NEW.RequestID,
                'OrderID', NEW.OrderID,
                'RawMaterialItemID', NEW.RawMaterialItemID,
                'WarehouseItemID', NEW.WarehouseItemID,
                'RequestedQty', NEW.RequestedQty,
                'UrgencyLevel', NEW.UrgencyLevel,
                'TriggerType', NEW.TriggerType
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_materialrequest_ad
AFTER DELETE ON MaterialRequest
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'MaterialRequest',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'RequestID', OLD.RequestID,
            'OrderID', OLD.OrderID,
            'RawMaterialItemID', OLD.RawMaterialItemID,
            'WarehouseItemID', OLD.WarehouseItemID,
            'RequestedQty', OLD.RequestedQty,
            'UrgencyLevel', OLD.UrgencyLevel,
            'TriggerType', OLD.TriggerType
        ),
        NULL
    );
END $$


/* Receipt */

CREATE TRIGGER trg_receipt_ai
AFTER INSERT ON Receipt
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'Receipt',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'ReceiptID', NEW.ReceiptID,
            'PurchaseID', NEW.PurchaseID,
            'POLineID', NEW.POLineID,
            'QtyReceived', NEW.QtyReceived,
            'ReceiptDate', NEW.ReceiptDate,
            'OutstandingQTY', NEW.OutstandingQTY
        )
    );
END $$

CREATE TRIGGER trg_receipt_au
AFTER UPDATE ON Receipt
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.ReceiptID <=> NEW.ReceiptID AND
        OLD.PurchaseID <=> NEW.PurchaseID AND
        OLD.POLineID <=> NEW.POLineID AND
        OLD.QtyReceived <=> NEW.QtyReceived AND
        OLD.ReceiptDate <=> NEW.ReceiptDate AND
        OLD.OutstandingQTY <=> NEW.OutstandingQTY
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'Receipt',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'ReceiptID', OLD.ReceiptID,
                'PurchaseID', OLD.PurchaseID,
                'POLineID', OLD.POLineID,
                'QtyReceived', OLD.QtyReceived,
                'ReceiptDate', OLD.ReceiptDate,
                'OutstandingQTY', OLD.OutstandingQTY
            ),
            JSON_OBJECT(
                'ReceiptID', NEW.ReceiptID,
                'PurchaseID', NEW.PurchaseID,
                'POLineID', NEW.POLineID,
                'QtyReceived', NEW.QtyReceived,
                'ReceiptDate', NEW.ReceiptDate,
                'OutstandingQTY', NEW.OutstandingQTY
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_receipt_ad
AFTER DELETE ON Receipt
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'Receipt',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'ReceiptID', OLD.ReceiptID,
            'PurchaseID', OLD.PurchaseID,
            'POLineID', OLD.POLineID,
            'QtyReceived', OLD.QtyReceived,
            'ReceiptDate', OLD.ReceiptDate,
            'OutstandingQTY', OLD.OutstandingQTY
        ),
        NULL
    );
END $$F


/* TransferForm_WarehouseItem */

CREATE TRIGGER trg_transferformwarehouseitem_ai
AFTER INSERT ON TransferForm_WarehouseItem
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'TransferForm_WarehouseItem',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'TransferLineID', NEW.TransferLineID,
            'TransferID', NEW.TransferID,
            'FromWarehouseItemID', NEW.FromWarehouseItemID,
            'ToWarehouseItemID', NEW.ToWarehouseItemID,
            'TransferQuantity', NEW.TransferQuantity
        )
    );
END $$

CREATE TRIGGER trg_transferformwarehouseitem_au
AFTER UPDATE ON TransferForm_WarehouseItem
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.TransferLineID <=> NEW.TransferLineID AND
        OLD.TransferID <=> NEW.TransferID AND
        OLD.FromWarehouseItemID <=> NEW.FromWarehouseItemID AND
        OLD.ToWarehouseItemID <=> NEW.ToWarehouseItemID AND
        OLD.TransferQuantity <=> NEW.TransferQuantity
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'TransferForm_WarehouseItem',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'TransferLineID', OLD.TransferLineID,
                'TransferID', OLD.TransferID,
                'FromWarehouseItemID', OLD.FromWarehouseItemID,
                'ToWarehouseItemID', OLD.ToWarehouseItemID,
                'TransferQuantity', OLD.TransferQuantity
            ),
            JSON_OBJECT(
                'TransferLineID', NEW.TransferLineID,
                'TransferID', NEW.TransferID,
                'FromWarehouseItemID', NEW.FromWarehouseItemID,
                'ToWarehouseItemID', NEW.ToWarehouseItemID,
                'TransferQuantity', NEW.TransferQuantity
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_transferformwarehouseitem_ad
AFTER DELETE ON TransferForm_WarehouseItem
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'TransferForm_WarehouseItem',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'TransferLineID', OLD.TransferLineID,
            'TransferID', OLD.TransferID,
            'FromWarehouseItemID', OLD.FromWarehouseItemID,
            'ToWarehouseItemID', OLD.ToWarehouseItemID,
            'TransferQuantity', OLD.TransferQuantity
        ),
        NULL
    );
END $$

/* Shipment */

CREATE TRIGGER trg_shipment_ai
AFTER INSERT ON Shipment
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (UUID(), @current_staff_id, 'Create', 'Shipment', CURRENT_TIMESTAMP, NULL,
        JSON_OBJECT(
            'ShipmentID', NEW.ShipmentID,
            'OrderID', NEW.OrderID,
            'TrackingNumber', NEW.TrackingNumber,
            'ShipDate', NEW.ShipDate,
            'DeliveryMethod', NEW.DeliveryMethod,
            'ShipmentStatus', NEW.ShipmentStatus,
            'ShipmentType', NEW.ShipmentType,
            'TotalAmount', NEW.TotalAmount
        )
    );
END $$

CREATE TRIGGER trg_shipment_au
AFTER UPDATE ON Shipment
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.ShipmentID <=> NEW.ShipmentID AND
        OLD.OrderID <=> NEW.OrderID AND
        OLD.TrackingNumber <=> NEW.TrackingNumber AND
        OLD.ShipDate <=> NEW.ShipDate AND
        OLD.DeliveryMethod <=> NEW.DeliveryMethod AND
        OLD.ShipmentStatus <=> NEW.ShipmentStatus AND
        OLD.ShipmentType <=> NEW.ShipmentType AND
        OLD.TotalAmount <=> NEW.TotalAmount
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (UUID(), @current_staff_id, 'Edit', 'Shipment', CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'ShipmentID', OLD.ShipmentID,
                'OrderID', OLD.OrderID,
                'TrackingNumber', OLD.TrackingNumber,
                'ShipDate', OLD.ShipDate,
                'DeliveryMethod', OLD.DeliveryMethod,
                'ShipmentStatus', OLD.ShipmentStatus,
                'ShipmentType', OLD.ShipmentType,
                'TotalAmount', OLD.TotalAmount
            ),
            JSON_OBJECT(
                'ShipmentID', NEW.ShipmentID,
                'OrderID', NEW.OrderID,
                'TrackingNumber', NEW.TrackingNumber,
                'ShipDate', NEW.ShipDate,
                'DeliveryMethod', NEW.DeliveryMethod,
                'ShipmentStatus', NEW.ShipmentStatus,
                'ShipmentType', NEW.ShipmentType,
                'TotalAmount', NEW.TotalAmount
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_shipment_ad
AFTER DELETE ON Shipment
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (UUID(), @current_staff_id, 'Delete', 'Shipment', CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'ShipmentID', OLD.ShipmentID,
            'OrderID', OLD.OrderID,
            'TrackingNumber', OLD.TrackingNumber,
            'ShipDate', OLD.ShipDate,
            'DeliveryMethod', OLD.DeliveryMethod,
            'ShipmentStatus', OLD.ShipmentStatus,
            'ShipmentType', OLD.ShipmentType,
            'TotalAmount', OLD.TotalAmount
        ),
        NULL
    );
END $$

/* ShipmentLine */

CREATE TRIGGER trg_shipmentline_ai
AFTER INSERT ON ShipmentLine
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'ShipmentLine',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'ShipmentLineID', NEW.ShipmentLineID,
            'ShipmentID', NEW.ShipmentID,
            'OrderID', NEW.OrderID,
            'ItemID', NEW.ItemID,
            'QtyShipped', NEW.QtyShipped,
            'QtyOutstanding', NEW.QtyOutstanding
        )
    );
END $$

CREATE TRIGGER trg_shipmentline_au
AFTER UPDATE ON ShipmentLine
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.ShipmentLineID <=> NEW.ShipmentLineID AND
        OLD.ShipmentID <=> NEW.ShipmentID AND
        OLD.OrderID <=> NEW.OrderID AND
        OLD.ItemID <=> NEW.ItemID AND
        OLD.QtyShipped <=> NEW.QtyShipped AND
        OLD.QtyOutstanding <=> NEW.QtyOutstanding
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'ShipmentLine',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'ShipmentLineID', OLD.ShipmentLineID,
                'ShipmentID', OLD.ShipmentID,
                'OrderID', OLD.OrderID,
                'ItemID', OLD.ItemID,
                'QtyShipped', OLD.QtyShipped,
                'QtyOutstanding', OLD.QtyOutstanding
            ),
            JSON_OBJECT(
                'ShipmentLineID', NEW.ShipmentLineID,
                'ShipmentID', NEW.ShipmentID,
                'OrderID', NEW.OrderID,
                'ItemID', NEW.ItemID,
                'QtyShipped', NEW.QtyShipped,
                'QtyOutstanding', NEW.QtyOutstanding
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_shipmentline_ad
AFTER DELETE ON ShipmentLine
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'ShipmentLine',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'ShipmentLineID', OLD.ShipmentLineID,
            'ShipmentID', OLD.ShipmentID,
            'OrderID', OLD.OrderID,
            'ItemID', OLD.ItemID,
            'QtyShipped', OLD.QtyShipped,
            'QtyOutstanding', OLD.QtyOutstanding
        ),
        NULL
    );
END $$


/* DeliveryNote */

CREATE TRIGGER trg_deliverynote_ai
AFTER INSERT ON DeliveryNote
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'DeliveryNote',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'DeliveryID', NEW.DeliveryID,
            'ShipmentID', NEW.ShipmentID,
            'DeliveryDate', NEW.DeliveryDate,
            'Outstanding_qty', NEW.Outstanding_qty,
            'ShippingAddress', NEW.ShippingAddress,
            'ShipToName', NEW.ShipToName
        )
    );
END $$

CREATE TRIGGER trg_deliverynote_au
AFTER UPDATE ON DeliveryNote
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.DeliveryID <=> NEW.DeliveryID AND
        OLD.ShipmentID <=> NEW.ShipmentID AND
        OLD.DeliveryDate <=> NEW.DeliveryDate AND
        OLD.Outstanding_qty <=> NEW.Outstanding_qty AND
        OLD.ShippingAddress <=> NEW.ShippingAddress AND
        OLD.ShipToName <=> NEW.ShipToName
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'DeliveryNote',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'DeliveryID', OLD.DeliveryID,
                'ShipmentID', OLD.ShipmentID,
                'DeliveryDate', OLD.DeliveryDate,
                'Outstanding_qty', OLD.Outstanding_qty,
                'ShippingAddress', OLD.ShippingAddress,
                'ShipToName', OLD.ShipToName
            ),
            JSON_OBJECT(
                'DeliveryID', NEW.DeliveryID,
                'ShipmentID', NEW.ShipmentID,
                'DeliveryDate', NEW.DeliveryDate,
                'Outstanding_qty', NEW.Outstanding_qty,
                'ShippingAddress', NEW.ShippingAddress,
                'ShipToName', NEW.ShipToName
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_deliverynote_ad
AFTER DELETE ON DeliveryNote
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'DeliveryNote',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'DeliveryID', OLD.DeliveryID,
            'ShipmentID', OLD.ShipmentID,
            'DeliveryDate', OLD.DeliveryDate,
            'Outstanding_qty', OLD.Outstanding_qty,
            'ShippingAddress', OLD.ShippingAddress,
            'ShipToName', OLD.ShipToName
        ),
        NULL
    );
END $$



/* ReplySlip */

CREATE TRIGGER trg_replyslip_ai
AFTER INSERT ON ReplySlip
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'ReplySlip',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'SlipID', NEW.SlipID,
            'DeliveryID', NEW.DeliveryID,
            'ActualRecipient', NEW.ActualRecipient,
            'ReceivedDate', NEW.ReceivedDate,
            'RecipientRemark', NEW.RecipientRemark
        )
    );
END $$

CREATE TRIGGER trg_replyslip_au
AFTER UPDATE ON ReplySlip
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.SlipID <=> NEW.SlipID AND
        OLD.DeliveryID <=> NEW.DeliveryID AND
        OLD.ActualRecipient <=> NEW.ActualRecipient AND
        OLD.ReceivedDate <=> NEW.ReceivedDate AND
        OLD.RecipientRemark <=> NEW.RecipientRemark
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'ReplySlip',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'SlipID', OLD.SlipID,
                'DeliveryID', OLD.DeliveryID,
                'ActualRecipient', OLD.ActualRecipient,
                'ReceivedDate', OLD.ReceivedDate,
                'RecipientRemark', OLD.RecipientRemark
            ),
            JSON_OBJECT(
                'SlipID', NEW.SlipID,
                'DeliveryID', NEW.DeliveryID,
                'ActualRecipient', NEW.ActualRecipient,
                'ReceivedDate', NEW.ReceivedDate,
                'RecipientRemark', NEW.RecipientRemark
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_replyslip_ad
AFTER DELETE ON ReplySlip
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'ReplySlip',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'SlipID', OLD.SlipID,
            'DeliveryID', OLD.DeliveryID,
            'ActualRecipient', OLD.ActualRecipient,
            'ReceivedDate', OLD.ReceivedDate,
            'RecipientRemark', OLD.RecipientRemark
        ),
        NULL
    );
END $$



/* ReturnOrder */

CREATE TRIGGER trg_returnorder_ai
AFTER INSERT ON ReturnOrder
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (UUID(), @current_staff_id, 'Create', 'ReturnOrder', CURRENT_TIMESTAMP, NULL,
        JSON_OBJECT(
            'ReturnID', NEW.ReturnID,
            'OrderID', NEW.OrderID,
            'ReturnDate', NEW.ReturnDate,
            'Reason', NEW.Reason,
            'RefundAmount', NEW.RefundAmount,
            'ReturnStatus', NEW.ReturnStatus
        )
    );
END $$

CREATE TRIGGER trg_returnorder_au
AFTER UPDATE ON ReturnOrder
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.ReturnID <=> NEW.ReturnID AND
        OLD.OrderID <=> NEW.OrderID AND
        OLD.ReturnDate <=> NEW.ReturnDate AND
        OLD.Reason <=> NEW.Reason AND
        OLD.RefundAmount <=> NEW.RefundAmount AND
        OLD.ReturnStatus <=> NEW.ReturnStatus
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (UUID(), @current_staff_id, 'Edit', 'ReturnOrder', CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'ReturnID', OLD.ReturnID,
                'OrderID', OLD.OrderID,
                'ReturnDate', OLD.ReturnDate,
                'Reason', OLD.Reason,
                'RefundAmount', OLD.RefundAmount,
                'ReturnStatus', OLD.ReturnStatus
            ),
            JSON_OBJECT(
                'ReturnID', NEW.ReturnID,
                'OrderID', NEW.OrderID,
                'ReturnDate', NEW.ReturnDate,
                'Reason', NEW.Reason,
                'RefundAmount', NEW.RefundAmount,
                'ReturnStatus', NEW.ReturnStatus
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_returnorder_ad
AFTER DELETE ON ReturnOrder
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (UUID(), @current_staff_id, 'Delete', 'ReturnOrder', CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'ReturnID', OLD.ReturnID,
            'OrderID', OLD.OrderID,
            'ReturnDate', OLD.ReturnDate,
            'Reason', OLD.Reason,
            'RefundAmount', OLD.RefundAmount,
            'ReturnStatus', OLD.ReturnStatus
        ),
        NULL
    );
END $$


/* ReturnOrderItem */

CREATE TRIGGER trg_returnorderitem_ai
AFTER INSERT ON ReturnOrderItem
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Create',
        'ReturnOrderItem',
        CURRENT_TIMESTAMP,
        NULL,
        JSON_OBJECT(
            'ReturnItemID', NEW.ReturnItemID,
            'ReturnID', NEW.ReturnID,
            'ShipmentLineID', NEW.ShipmentLineID,
            'Quantity', NEW.Quantity
        )
    );
END $$

CREATE TRIGGER trg_returnorderitem_au
AFTER UPDATE ON ReturnOrderItem
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.ReturnItemID <=> NEW.ReturnItemID AND
        OLD.ReturnID <=> NEW.ReturnID AND
        OLD.ShipmentLineID <=> NEW.ShipmentLineID AND
        OLD.Quantity <=> NEW.Quantity
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (
            UUID(),
            @current_staff_id,
            'Edit',
            'ReturnOrderItem',
            CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'ReturnItemID', OLD.ReturnItemID,
                'ReturnID', OLD.ReturnID,
                'ShipmentLineID', OLD.ShipmentLineID,
                'Quantity', OLD.Quantity
            ),
            JSON_OBJECT(
                'ReturnItemID', NEW.ReturnItemID,
                'ReturnID', NEW.ReturnID,
                'ShipmentLineID', NEW.ShipmentLineID,
                'Quantity', NEW.Quantity
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_returnorderitem_ad
AFTER DELETE ON ReturnOrderItem
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (
        UUID(),
        @current_staff_id,
        'Delete',
        'ReturnOrderItem',
        CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'ReturnItemID', OLD.ReturnItemID,
            'ReturnID', OLD.ReturnID,
            'ShipmentLineID', OLD.ShipmentLineID,
            'Quantity', OLD.Quantity
        ),
        NULL
    );
END $$


/* Complaint */

CREATE TRIGGER trg_complaint_ai
AFTER INSERT ON Complaint
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (UUID(), COALESCE(@current_staff_id, NEW.StaffID), 'Create', 'Complaint', CURRENT_TIMESTAMP, NULL,
        JSON_OBJECT(
            'ComplaintID', NEW.ComplaintID,
            'OrderID', NEW.OrderID,
            'StaffID', NEW.StaffID,
            'ComplaintDescription', NEW.ComplaintDescription,
            'ComplaintStatus', NEW.ComplaintStatus
        )
    );
END $$

CREATE TRIGGER trg_complaint_au
AFTER UPDATE ON Complaint
FOR EACH ROW
BEGIN
    IF NOT (
        OLD.ComplaintID <=> NEW.ComplaintID AND
        OLD.OrderID <=> NEW.OrderID AND
        OLD.StaffID <=> NEW.StaffID AND
        OLD.ComplaintDescription <=> NEW.ComplaintDescription AND
        OLD.ComplaintStatus <=> NEW.ComplaintStatus
    ) THEN
        INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
        VALUES (UUID(), COALESCE(@current_staff_id, NEW.StaffID, OLD.StaffID), 'Edit', 'Complaint', CURRENT_TIMESTAMP,
            JSON_OBJECT(
                'ComplaintID', OLD.ComplaintID,
                'OrderID', OLD.OrderID,
                'StaffID', OLD.StaffID,
                'ComplaintDescription', OLD.ComplaintDescription,
                'ComplaintStatus', OLD.ComplaintStatus
            ),
            JSON_OBJECT(
                'ComplaintID', NEW.ComplaintID,
                'OrderID', NEW.OrderID,
                'StaffID', NEW.StaffID,
                'ComplaintDescription', NEW.ComplaintDescription,
                'ComplaintStatus', NEW.ComplaintStatus
            )
        );
    END IF;
END $$

CREATE TRIGGER trg_complaint_ad
AFTER DELETE ON Complaint
FOR EACH ROW
BEGIN
    INSERT INTO `Log` (`LogID`, `StaffID`, `LogType`, `TargetTable`, `LogTimeStamp`, `OldValue`, `NewValue`)
    VALUES (UUID(), COALESCE(@current_staff_id, OLD.StaffID), 'Delete', 'Complaint', CURRENT_TIMESTAMP,
        JSON_OBJECT(
            'ComplaintID', OLD.ComplaintID,
            'OrderID', OLD.OrderID,
            'StaffID', OLD.StaffID,
            'ComplaintDescription', OLD.ComplaintDescription,
            'ComplaintStatus', OLD.ComplaintStatus
        ),
        NULL
    );
END $$


DELIMITER ;