package android.cs453.pdtapplication;

public class Product {

    private int productID;
    private String barcode;
    private String cost;
    private String sale;
    private String name;
    private String description;
    private String discount;
    private String discountPer;

    public Product() {

    }

    public int getProductID() {
        return this.productID;
    }

    public void setProductID(int id) {
        this.productID = id;
    }

    public String getBarcode() {
        return this.barcode;
    }

    public void setBarcode(String code) {
        this.barcode = code;
    }

    public String getCost() {
        return cost;
    }

    public void setCost(String cost) {
        this.cost = cost;
    }

    public String getSale() {
        return this.sale;
    }

    public void setSale(String sale) {
        this.sale = sale;
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
