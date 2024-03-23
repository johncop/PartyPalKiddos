import React from "react";
import FeaturedPackageItem from "./featuredPackageItem";
import { useSelector } from "react-redux";
import { useEffect, useState } from "react";

export default function FeaturedPackages() {
  const state = useSelector((state) => state);
  const [packages, setPackages] = useState([]);
  useEffect(() => {
    setPackages(state.uiState.packages);
  }, [state.uiState.packages]);

  return (
    <section className="section-padding">
      <div className="auto-container">
        <div className="section_heading text-center mb-4">
          <h2 className="section_heading_title_big animation-text-head-color-hoz">Rooms & Suites</h2>
        </div>
        <div className="row">
          {packages.map((pkg, index) => (
            <div className="col-lg-3 col-md-6" key={"package-" + index}>
              <FeaturedPackageItem data={pkg} />
            </div>
          ))}
        </div>
      </div>
    </section>
  );
}
