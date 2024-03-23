export default function Login(props) {
    return <>
        <div className="login-container form-large">
            <div className="background"></div>
            <div className="container row px-0">
                <div className="item-des-login p-md-5 col-lg-7">
                    <h2 className="logo mb-5"><i className='bx bxl-xing'></i>PartyPal Kiddos</h2>
                    <div className="text-item text-white">
                        <h2 className="text-white">Welcome! <br /><span className="text-white">
                            To Our Channel
                        </span></h2>
                        <p className="text-white">Lorem ipsum dolor sit amet consectetur adipisicing elit. Rem labore culpa est molestias exercitationem magnam! Ut vero aut aperiam nihil vel labore reiciendis ex, culpa harum dolorem non. Voluptates, dolore.</p>
                        <div className="social-icon mb-3">
                            <a href="#"><i className='fab fa-facebook-f'></i></a>
                            <a href="#"><i className='fab fa-twitter'></i></a>
                            <a href="#"><i className='fab fa-youtube'></i></a>
                            <a href="#"><i className='fab fa-instagram'></i></a>
                            <a href="#"><i className='fab fa-linkedin'></i></a>
                        </div>
                    </div>
                </div>
                <div className="login-section col-lg-5">
                    <div className="form-box login">
                        <form action="" className="p-4 w-100">
                            <h2 className="text-white">Login</h2>
                            <div className="input-box">
                                <span className="icon"><i className='bx bxs-lock-alt' ></i></span>
                                <input className="text-white" type="text" required></input>
                                <label>Email</label>
                            </div>
                            <div className="input-box">
                                <span className="icon"><i className='bx bxs-lock-alt' ></i></span>
                                <input className="text-white" type="password" required></input>
                                <label>Password</label>
                            </div>
                            <div className="remember-password">
                                <label for=""><input type="checkbox"></input>Remember Me</label>
                                {/* <a href="#">Forget Password</a> */}
                            </div>
                            <button className="btn-login-custom">Login In</button>
                            <div className="create-account">
                                <p>Create A New Account? <a href="/sign-up" className="register-link">Sign Up</a></p>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>

    </>
}