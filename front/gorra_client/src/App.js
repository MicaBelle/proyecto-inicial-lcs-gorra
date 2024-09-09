import BottomMenu from "./components/bottomMenu/bottomMenu";
import MainContainer from "./components/mainContainer/mainContainer";
import ResponsiveAppBar from "./components/navbar/navbar";
import TopMenu from "./components/topMenu/topMenu";
import ReportCenter from "./pages/ReportCenter";
import Home from "./pages/Home";
import { Route, Routes } from "react-router-dom";
import MyReports from "./pages/MyReports";
import Login from "./pages/Login";
import Register from "./pages/Register";
import EditReport from "./pages/EditReport";

function App() {
  return (
    <div className="App">
      <TopMenu />
      <MainContainer>
        <Routes>
          <Route path="/home" Component={Home} />
          <Route path="/register" Component={Register} />
          <Route path="/report" Component={ReportCenter} />
          <Route path="/my-reports" Component={MyReports} />
          <Route path="/edit-report" Component={EditReport} />
          <Route path="/" Component={Login} />
        </Routes>
      </MainContainer>
      <BottomMenu />
    </div>
  );
}

export default App;
