export class UserModel {
  private userId: string;
  private userName: string;
  private userPhone: string;
  private userEmail: string;

  constructor(userId, userName, userPhone, userEmail) {
    this.userId = userId;
    this.userName = userName;
    this.userPhone = userPhone;
    this.userEmail = userEmail;
  }
}
