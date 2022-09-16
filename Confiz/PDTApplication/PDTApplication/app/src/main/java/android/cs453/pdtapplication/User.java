package android.cs453.pdtapplication;

import android.os.Parcel;
import android.os.Parcelable;

import java.util.Date;

//implementing parcelable to pass current user information to other classes
public class User implements Parcelable {
    private String USERID;
    private String USERNAME;
    private String PASSWORD;
    private Date dateCreated;

    //
    public static final Parcelable.Creator CREATOR = new Parcelable.Creator() {
        public User createFromParcel(Parcel in) {
            return new User(in);
        }

        public User[] newArray(int size) {
            return new User[size];
        }
    };

    public User() {
    }

    public User(String id, String pw) {
        this.USERID = id;
        this.PASSWORD = pw;
    }

    public String getUserID() {
        return USERID;
    }

    public void setUserID(String id) {
        this.USERID = id;
    }

    public String getPassword() {
        return PASSWORD;
    }

    public void setPassword(String pw) {
        this.PASSWORD = pw;
    }

    public String getUsername() {
        return this.USERNAME;
    }

    public void setUsername(String name) {
        this.USERNAME = name;
    }

    public Date getDateCreated() {
        return dateCreated;
    }

    public User (Parcel in) {
        this.USERID = in.readString();
        this.PASSWORD = in.readString();
    }

    @Override
    public int describeContents() {
        return 0;
    }

    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(this.USERID);
        dest.writeString(this.PASSWORD);
    }
}
