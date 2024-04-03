import { initializeApp } from "firebase/app";
import { getStorage, ref, uploadBytes, getDownloadURL } from "firebase/storage";
import { toast } from "react-toastify";

// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyDjCzI6Z6JU7wsZ0sYtr5hYyfJeHQiSsKI",
  authDomain: "party-booking-92deb.firebaseapp.com",
  projectId: "party-booking-92deb",
  storageBucket: "party-booking-92deb.appspot.com",
  messagingSenderId: "143193685826",
  appId: "1:143193685826:web:1910dafabe8580eedc12db",
  measurementId: "G-LX6JB2TMBV",
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);

const storage = getStorage(app);

export const handleUpload = (path, image, callback) => {
  if (image) {
    const storageRef = ref(
      storage,
      `${path}/${new Date()
        .toISOString()
        .replace(/:/g, "_")
        .replace(/\..+/, "")}_${image.name}`
    );

    // 'file' comes from the Blob or File API
    uploadBytes(storageRef, image)
      .then((snapshot) => {
        getDownloadURL(snapshot.ref)
          .then((downloadURL) => {
            callback(downloadURL);
          })
          .catch((error) => {
            toast.error(error.message, {
              position: "bottom-center",
              autoClose: 2000,
            });
          });
      })
      .catch((error) => {
        toast.error(error.message, {
          position: "bottom-center",
          autoClose: 2000,
        });
      });
  } else {
    callback(null);
  }
};
