export class UserModel {
  public userId: string;
  public userName: string;
  public userPhone: string;
  public userEmail: string;

  constructor(userId, userName, userPhone, userEmail) {
    this.userId = userId;
    this.userName = userName;
    this.userPhone = userPhone;
    this.userEmail = userEmail;
  }
}
