import { ListingPage } from "../pages/ListingPage";
import { LoginRegisterPage } from "../pages/LoginRegisterPage";

const AppRoutes = [
  {
    index: true,
    element: <LoginRegisterPage />
  },
  {
    path: '/listing',
    element: <ListingPage />
  },
  {
    path: '/listing',
    element: <ListingPage />
  }
];

export default AppRoutes;
