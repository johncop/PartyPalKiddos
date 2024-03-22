import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

export default function Profile() {
    const params = useParams();
    const { id } = params;
    const [isEdit, setIsEdit] = useState(false);
    const [imgSrc, setImgSrc] = useState("https://images.squarespace-cdn.com/content/v1/54b7b93ce4b0a3e130d5d232/1519986430884-H1GYNRLHN0VFRF6W5TAN/icon.png?format=500w");

    function handleSubmitEdit(e) {
        e.preventDefault();
    }
    useEffect(() => {
        // Check avt exist
        const imageExists = async (url) => {
            let result = "";
            if(url !== "") {
                try {
                    const response = await fetch(url);
                    if (response.ok) {
                        setImgSrc(url);
                    } else {
                        throw new Error('Not exist image');
                    }
                } catch (error) {
                }
            }
            return result;
        }
        imageExists(imgSrc)
    })

    return <>
        <section className="section-padding">
            <div className="auto-container">
                <div className="row">
                    <div className="col-md-4 mb-3">
                        <div className="card p-3">
                            <div className="text-center">
                                <img src={imgSrc} width={150} alt="Profile Picture" className="profile-img b_radius_50"></img>
                                <h4 className="mt-3 animation-text-head-color-hoz">John Doe</h4>
                                <p>Web Developer</p>
                                <hr />
                                <h5 className="mb-2">BIOGRAPHY</h5>
                                <p className="mb-4 px-3" style={{ lineHeight: 1.2 }}>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias quas mollitia officiis culpa expedita illo ex ab inventore odio atque?</p>
                                <button className="btn btn-primary" onClick={() => setIsEdit(true)} >Edit Profile</button>
                            </div>
                        </div>
                    </div>
                    <div className="col-md-8">
                        {
                            isEdit ? <div className="card">
                                <div className="card-body">
                                    <div className="d-flex justify-content-between mb-2 align-items-center">
                                        <h5 className="card-title">Basic info</h5>
                                        <div className="d-flex gap-3">
                                            <button className="btn btn-outline-info" style={{ width: 90 }} onClick={() => setIsEdit(false)}>CANCEL</button>
                                            <button className="btn btn-info text-white" type="submit" style={{ width: 90 }} onClick={(e) => handleSubmitEdit(e)}>SAVE</button>
                                        </div>
                                    </div>
                                    <hr />
                                    <div>
                                        <form>
                                            <div className="form-group mb-2">
                                                <label htmlFor="fullname" className="text-dark">Full name:</label>
                                                <input type="text" className="form-control w-100" id="fullname" placeholder="Enter full name" required onChange={(e) => { }}></input>
                                            </div>
                                            <div className="form-group mb-2">
                                                <label htmlFor="email" className="text-dark">Email addresss:</label>
                                                <input type="email" className="form-control w-100" id="email" placeholder="Enter Email" required onChange={(e) => { }}></input>
                                            </div>
                                            <h5 className="card-title mt-4">About me</h5>
                                            <div className="form-group mb-2">
                                                <label htmlFor="biography" className="text-dark">Biography:</label>
                                                <textarea className="form-control w-100" id="biography" placeholder=""></textarea>
                                            </div>
                                            <h5 className="card-title mt-4">External links</h5>
                                            <hr />
                                            <div className="form-group mb-2">
                                                <label htmlFor="facebook" className="text-dark">Facebook URL:</label>
                                                <input type="text" className="form-control w-100" id="facebook" placeholder="Past your link here" onChange={(e) => { }}></input>
                                            </div>
                                            <div className="form-group mb-2">
                                                <label htmlFor="twitter" className="text-dark">Twitter URL:</label>
                                                <input type="email" className="form-control w-100" id="twitter" placeholder="Enter your email" onChange={(e) => { }}></input>
                                            </div>
                                            <div className="form-group mb-2">
                                                <label htmlFor="linkedin" className="text-dark">LinkedIn URL:</label>
                                                <input type="text" className="form-control w-100" id="linkedin" placeholder="Past your link here" onChange={(e) => { }}></input>
                                            </div>
                                            <div className="form-group mb-2">
                                                <label htmlFor="telegram" className="text-dark">Telegram URL:</label>
                                                <input type="email" className="form-control w-100" id="telegram" placeholder="Enter your email" onChange={(e) => { }}></input>
                                            </div>
                                            <h5 className="card-title mt-4">Security</h5>
                                            <hr />
                                            <div className="form-group mb-4">
                                                <label htmlFor="pwd">Password:</label>
                                                <input type="password" className="form-control w-100" id="pwd" placeholder="Enter Password" required></input>
                                            </div>
                                            <div className="form-group mb-4">
                                                <label htmlFor="npwd">New Password:</label>
                                                <input type="password" className="form-control w-100" id="npwd" placeholder="New Password" required></input>
                                            </div>
                                            <div className="form-group mb-4">
                                                <label htmlFor="vpwd">Verify Password:</label>
                                                <input type="password" className="form-control w-100" id="vpwd" placeholder="Verify Password" required></input>
                                            </div>
                                            <div className="d-flex gap-3 justify-content-end">
                                                <button className="btn btn-outline-info" style={{ width: 90 }} onClick={() => setIsEdit(false)}>CANCEL</button>
                                                <button className="btn btn-info text-white" type="submit" style={{ width: 90 }} onClick={(e) => handleSubmitEdit(e)}>SAVE</button>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div> : <div className="card">
                                <div className="card-body">
                                    <h5 className="card-title">About Me</h5>
                                    <p className="card-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam facilisis quam sit amet dolor ultricies, sit amet consequat magna bibendum. Sed suscipit augue sit amet eros interdum, eu mattis massa laoreet.</p>
                                    <h5 className="card-title">Contact Information</h5>
                                    <p className="card-text">Email: john@example.com <br /> Phone: +1234567890<br />Address: 123 Street, City, Country</p>
                                    <h5 className="card-title">Skills</h5>
                                    <ul className="list-group">
                                        <li className="list-group-item">HTML</li>
                                        <li className="list-group-item">CSS</li>
                                        <li className="list-group-item">JavaScript</li>
                                        <li className="list-group-item">Bootstrap</li>
                                    </ul>
                                </div>
                            </div>
                        }

                    </div>
                </div>
            </div>
        </section>
    </>
}