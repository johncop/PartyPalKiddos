export default function FormContact() {
    return <>
        <form>
            <div className="form-group mb-2">
                <label htmlFor="fullname" className="fw_sbold">Full Name</label>
                <input type="text" className="form-control w-100" id="fullname" placeholder="Enter Name"></input>
            </div>
            <div className="form-group mb-2">
                <label htmlFor="contactnumber" className="fw_sbold">Contact Number</label>
                <input type="tel" className="form-control w-100" id="phoneNumber" placeholder="Enter phone number" pattern="[0-9]{10,11}" required></input>
            </div>
            <div className="form-group mb-2">
                <label htmlFor="email" className="fw_sbold">Email address</label>
                <input type="email" required className="form-control w-100" id="email" aria-describedby="emailHelp" placeholder="Enter email"></input>
            </div>
            <div className="form-group mb-2">
                <label htmlFor="message" className="fw_sbold">Message</label>
                <textarea required className="form-control w-100" id="message" placeholder="Enter Your Message"></textarea>
            </div>
            <button type="submit" className="btn btn-primary w-100">Submit</button>
        </form>
    </>
}