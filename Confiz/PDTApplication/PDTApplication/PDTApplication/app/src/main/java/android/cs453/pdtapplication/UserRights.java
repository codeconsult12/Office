package android.cs453.pdtapplication;

public class UserRights {

    private String HHTUserRoleCode;
    private String TransactionType;

    public UserRights() {
    }

    public String getHHTUserRoleCode() {
        return this.HHTUserRoleCode;
    }

    public void setHHTUserRoleCode(String role) {
        this.HHTUserRoleCode = role;
    }

    public String getTransactionType() {
        return this.TransactionType;
    }

    public void setTransactionType(String transaction) {
        this.TransactionType = transaction;
    }
}
