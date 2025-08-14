import { useFetchUser, useLogOutUser } from "../hooks/UserHooks";
import config from "../config";
import { useNavigate } from "react-router";
import type { Claim } from "../types/Claim";

type Props = {
  title: string;
};

const Header = ({ title }: Props) => {
  const { isSuccess, data } = useFetchUser();
  const loginUrl = `${config.baseApiUrl}/account/login`;
  const registerUrl = `${config.baseApiUrl}/account/register`;
  const logoutMutation = useLogOutUser();
  const nav = useNavigate();
  return (
    <header className="row mb-5">
      <div className="col-5">
        <h1 className="text-center" onClick={() => nav("/")}>
          {title}
        </h1>
      </div>
      <div className="col-7">
        {isSuccess ? (
          <>
            {data.find((c: Claim) => c.type === "name")}
            <button onClick={() => logoutMutation.mutate()}>Logout</button>
          </>
        ) : (
          <nav className="nav justify-content-end">
            <a className="nav-link" href={loginUrl}>
              Login
            </a>
            <a className="nav-link" href={registerUrl}>
              Register
            </a>
          </nav>
        )}
      </div>
    </header>
  );
};

export default Header;
