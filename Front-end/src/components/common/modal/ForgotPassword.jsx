import axios from "axios";
import { useState } from "react";
import { toast } from "react-toastify";

export function ForgotPassword() {
  const [isEnterCode, setIsEnterCode] = useState(false);
  function handleSubmit(e) {
    e.preventDefault();
    if (isEnterCode === false) {
      axios
        .post(`${process.env.REACT_APP_API_BASE_URL}users/forgot-password`, {
          email: e.target[0].value,
        })
        .then((response) => {
          setIsEnterCode(true);
          toast.info("Please enter the confirmation code as the old password", {
            position: "bottom-center",
            autoClose: 2000,
          });
        })
        .catch(() => {
          toast.error("Account has not been created yet", {
            position: "bottom-center",
            autoClose: 2000,
          });
        });
    } else {
      axios
        .post(`${process.env.REACT_APP_API_BASE_URL}users/change-password`, {
          oldPassword: e.target[0].value,
          newPassword: e.target[1].value,
          confirmPassword: e.target[2].value,
        })
        .then((response) => {
          toast.info("Changed password successfully", {
            position: "bottom-center",
            autoClose: 2000,
          });
        })
        .catch(() => {
          toast.error("InValid Value", {
            position: "bottom-center",
            autoClose: 2000,
          });
        });
    }
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
            {isEnterCode ? (
              <div className="form-box login">
                <form
                  action=""
                  className="p-4 w-100"
                  method="post"
                  onSubmit={(e) => handleSubmit(e)}
                >
                  <h2 className="text-white">Forgot Password</h2>
                  <div className="input-box">
                    <span className="icon">
                      <i className="bx bxs-lock-alt"></i>
                    </span>
                    <input
                      className="text-white"
                      type="text"
                      required
                      value={""}
                      onChange={() => {}}
                    ></input>
                    <label>Code</label>
                  </div>
                  <div className="input-box">
                    <span className="icon">
                      <i className="bx bxs-lock-alt"></i>
                    </span>
                    <input
                      className="text-white"
                      type="text"
                      required
                      value={""}
                      onChange={() => {}}
                    ></input>
                    <label>New Password</label>
                  </div>
                  <div className="input-box">
                    <span className="icon">
                      <i className="bx bxs-lock-alt"></i>
                    </span>
                    <input
                      className="text-white"
                      type="text"
                      required
                      value={""}
                      onChange={() => {}}
                    ></input>
                    <label>Re - Password</label>
                  </div>
                  <button className="btn-login-custom">Submit</button>
                  <div className="create-account">
                    <p>
                      Incorrectly entered gmail?{" "}
                      <span
                        className="register-link cursor-pointer"
                        onClick={() => setIsEnterCode(false)}
                      >
                        Re-enter gmail
                      </span>
                    </p>
                  </div>
                </form>
              </div>
            ) : (
              <div className="form-box login">
                <form
                  action=""
                  className="p-4 w-100"
                  method="post"
                  onSubmit={(e) => handleSubmit(e)}
                >
                  <h2 className="text-white">Forgot Password</h2>
                  <div className="input-box">
                    <span className="icon">
                      <i className="bx bxs-lock-alt"></i>
                    </span>
                    <input className="text-white" type="text" required></input>
                    <label>Email</label>
                  </div>
                  <button className="btn-login-custom">Submit</button>
                </form>
              </div>
            )}
          </div>
        </div>
      </div>
    </>
  );
}
