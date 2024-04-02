import axios from "axios";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

export default function SignUp(props) {
  async function handleSubmit(e) {
    e.preventDefault();
    if (e.target[5].value !== e.target[6].value) {
      toast.info("Password & Re-password don't' match", {
        position: "bottom-center",
        autoClose: 2000,
      });
      return;
    }
    await axios
      .post(`${process.env.REACT_APP_API_BASE_URL}auth/register`, {
        firstName: e.target[0].value,
        lastName: e.target[1].value,
        email: e.target[2].value,
        phoneNumber: e.target[3].value,
        address: e.target[4].value,
        password: e.target[5].value,
        confirmPassword: e.target[6].value,
      })
      .then((response) => {
        if (response.status === 200) {
          toast.info("Successfully registered", {
            position: "bottom-center",
            autoClose: 2000,
          });
          setTimeout(() => {
            window.location.href = "/login";
          }, 2000);
        } else {
          toast.error("Failed to register", {
            position: "bottom-center",
            autoClose: 2000,
          });
        }

        return response;
      })
      .catch((error) => {
        toast.error(error.message, {
          position: "bottom-center",
          autoClose: 2000,
        });
        return error;
      });
  }
  return (
    <>
      <div className="login-container form-large">
        <div className="background"></div>
        <div className="container row px-0">
          <div className="item-des-login p-md-5 col-lg-7">
            <h2 className="logo mb-5">
              <i className="bx bxl-xing"></i>PartyPal Kiddos
            </h2>
            <div className="text-item text-white">
              <h2 className="text-white">
                Welcome! <br />
                <span className="text-white">To Our Channel</span>
              </h2>
              <p className="text-white">
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem
                labore culpa est molestias exercitationem magnam! Ut vero aut
                aperiam nihil vel labore reiciendis ex, culpa harum dolorem non.
                Voluptates, dolore.
              </p>
              <div className="social-icon mb-3 d-flex gap-2">
                <a href="#">
                  <div>
                    <i className="fab fa-facebook-f"></i>
                  </div>
                </a>
                <a href="#">
                  <div>
                    <i className="fab fa-twitter"></i>
                  </div>
                </a>
                <a href="#">
                  <div>
                    <i className="fab fa-youtube"></i>
                  </div>
                </a>
                <a href="#">
                  <div>
                    <i className="fab fa-instagram"></i>
                  </div>
                </a>
                <a href="#">
                  <div>
                    <i className="fab fa-linkedin"></i>
                  </div>
                </a>
              </div>
            </div>
          </div>
          <div className="login-section col-lg-5">
            <div className="form-box register">
              <form
                action=""
                className="p-4 w-100"
                onSubmit={(e) => handleSubmit(e)}
              >
                <h2 className="text-white">Sign Up</h2>
                <div className="input-box">
                  <span className="icon">
                    <i className="bx bxs-user"></i>
                  </span>
                  <input className="text-white" type="text" required></input>
                  <label>First Name</label>
                </div>
                <div className="input-box">
                  <span className="icon">
                    <i className="bx bxs-user"></i>
                  </span>
                  <input className="text-white" type="text" required></input>
                  <label>Last Name</label>
                </div>
                <div className="input-box">
                  <span className="icon">
                    <i className="bx bxs-lock-alt"></i>
                  </span>
                  <input className="text-white" type="email" required></input>
                  <label>Email</label>
                </div>
                <div className="input-box">
                  <span className="icon">
                    <i className="bx bxs-lock-alt"></i>
                  </span>
                  <input className="text-white" type="tel" required></input>
                  <label>Phone</label>
                </div>
                <div className="input-box">
                  <span className="icon">
                    <i className="bx bxs-lock-alt"></i>
                  </span>
                  <input className="text-white" type="text" required></input>
                  <label>Address</label>
                </div>
                <div className="input-box">
                  <span className="icon">
                    <i className="bx bxs-lock-alt"></i>
                  </span>
                  <input
                    className="text-white"
                    type="password"
                    required
                  ></input>
                  <label>Password</label>
                </div>
                <div className="input-box">
                  <span className="icon">
                    <i className="bx bxs-lock-alt"></i>
                  </span>
                  <input
                    className="text-white"
                    type="password"
                    required
                  ></input>
                  <label>Re - Password</label>
                </div>
                <button className="btn-login-custom">Sign up</button>
                <div className="create-account">
                  <p>
                    Already Have An Account?{" "}
                    <a href="/login" className="login-link">
                      Login
                    </a>
                  </p>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
      <ToastContainer />
    </>
  );
}
