package android.cs453.pdtapplication;

public class Price {
    private String barcode;
    private String itemcode;
    private String description;
    private String vendor;
    private String unitPrice;
    private String salesPrice;
    private String UOM;

    public Price() {
    }

    public Price(String barcode, String itemcode, String desc, String vendor, String unitPrice, String salesPrice) {
        this.barcode = barcode;
        this.itemcode = itemcode;
        this.description = desc;
        this.vendor = vendor;
        this.unitPrice = unitPrice;
        this.salesPrice = salesPrice;
    }

    public Price(String barcode, String itemcode, String desc, String uom, String vendor, String unitPrice, String salesPrice) {
        this.barcode = barcode;
        this.itemcode = itemcode;
        this.description = desc;
        this.UOM = uom;
        this.vendor = vendor;
        this.unitPrice = unitPrice;
        this.salesPrice = salesPrice;
    }

    public String getBarcode() {
        return this.barcode;
    }
    public void setBarcode(String barcode) {
        this.barcode = barcode;
    }
    public String getItemcode() {
        return this.itemcode;
    }
    public void setItemcode(String itemcode) {
        this.itemcode = itemcode;
    }
    public String getDescription() {
        return this.description;
    }
    public void setDescription(String desc) {
        this.description = desc;
    }
    public String getUOM() {
        return this.UOM;
    }
    public void setUOM(String uom) {
        this.UOM = uom;
    }
    public String getVendor() {
        return this.vendor;
    }
    public void setVendor(String vendor) {
        this.vendor = vendor;
    }
    public String getUnitPrice() {
        return this.unitPrice;
    }
    public void setUnitPrice(String price) {
        this.unitPrice = price;
    }
    public String getSalesPrice() {
        return this.salesPrice;
    }
    public void setSalesPrice(String price) {
        this.salesPrice = price;
    }
}
