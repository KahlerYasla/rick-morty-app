import { ListingPage } from "../pages/ListingPage";
import { HomePage } from "../pages/HomePage";

const AppRoutes = [
  {
    index: true,
    element: <HomePage />
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
