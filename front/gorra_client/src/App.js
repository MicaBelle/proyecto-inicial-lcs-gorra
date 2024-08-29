import BottomMenu from "./components/bottomMenu/bottomMenu";
import MainContainer from "./components/mainContainer/mainContainer";
import ResponsiveAppBar from "./components/navbar/navbar";
import TopMenu from "./components/topMenu/topMenu";
import ReportCenter from "./pages/ReportCenter";

function App() {
  return (
    <div className="App"> 
      <TopMenu/>

      <MainContainer>
        <ReportCenter/>
      </MainContainer>

      <BottomMenu/>
    </div>
  );
}

export default App;
