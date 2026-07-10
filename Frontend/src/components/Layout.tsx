import { Link, Outlet } from "react-router-dom";


function Layout(){

    return (

        <>

            <nav>

                <Link to="/">
                    Pessoas
                </Link>


                <Link to="/transacoes">
                    Transações
                </Link>


                <Link to="/totais">
                    Totais
                </Link>

            </nav>


            <main>

                <Outlet />

            </main>

        </>

    );

}


export default Layout;