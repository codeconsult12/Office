package android.cs453.pdtapplication;

public class Item {

    //private int productID;
    private String itemcode;
    private String barcode;
    private String salesCost;
    private String discountedCost;
    private String name;
    private String description;
    private String discount;
    private String discountPer;

    public Item() {

    }

    public String getBarcode() {
        return this.barcode;
    }

    public void setBarcode(String code) {
        this.barcode = code;
    }

    public String getItemcode() {
        return this.itemcode;
    }

    public String setItemCode(String code) {
        return this.itemcode = code;
    }

    public String getSalesCost() {
        return this.salesCost;
    }

    public void setSalesCost(String cost) {
        this.salesCost = cost;
    }

    public String getDiscountedCost() {
        return this.discountedCost;
    }

    public void setDiscountedCost(String cost) {
        this.discountedCost = cost;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String productName) {
        this.name = productName;
    }

    public String getDescription() {
        return this.description;
    }

    public void setDescription(String desc) {
        this.description = desc;
    }

    public String getDiscount() {
        return this.discount;
    }

    public void setDiscount(String discount) {
        this.discount = discount;
    }

    public String getDiscountPer() {
        return this.discountPer;
    }

    public void setDiscountPer(String discountPer) {
        this.discountPer = discountPer;
    }
}
