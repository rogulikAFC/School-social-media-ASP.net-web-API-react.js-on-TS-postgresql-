type User = {
  id: string;
  name: string;
  profileViewCount: number;
  imagePath: string;
  school: School;
};

type UserToSignUp = {
  name: string;
  schoolId: string | null;
  email: string;
};

type UserToLogin = {
  email: string;
  password: string;
}
