import BottomMenu from "./components/bottomMenu/bottomMenu";
import MainContainer from "./components/mainContainer/mainContainer";
import ResponsiveAppBar from "./components/navbar/navbar";
import TopMenu from "./components/topMenu/topMenu";
import ReportCenter from "./pages/ReportCenter";
import Home from "./pages/Home";
import { Route, Routes } from "react-router-dom";
import MyReports from "./pages/MyReports";

function App() {
  return (
    <div className="App">
      <TopMenu />
      <MainContainer>
        <Routes>
          <Route path="/" Component={Home} />
          <Route path="/report" Component={ReportCenter} />
          <Route path="/my-reports" Component={MyReports} />
        </Routes>
      </MainContainer>
      <BottomMenu />
    </div>
  );
}

export default App;
