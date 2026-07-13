import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom";

import Pessoas from "./pages/Pessoas";
import Transacoes from "./pages/Transacoes";
import Totais from "./pages/Totais";
import Layout from "./components/Layout";

//Componente principal da aplicação que define as rotas e o layout
function App() {

  return (

    <BrowserRouter>

      <Routes>

        <Route 
            element={<Layout />}
        >

            <Route 
                path="/"
                element={<Pessoas />}
            />

            <Route 
                path="/transacoes"
                element={<Transacoes />}
            />

            <Route 
                path="/totais"
                element={<Totais />}
            />

        </Route>
    </Routes>

    </BrowserRouter>
  )
}


export default App;