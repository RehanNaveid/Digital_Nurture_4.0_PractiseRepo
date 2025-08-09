import React, { useState } from "react";
import CourseDetails from "./CourseDetails";
import BookDetails from "./BookDetails";
import BlogDetails from "./BlogDetails";
import "./App.css";

function App() {
  const showCourses = true;
  const showBooks = true;
  const showBlogs = true;

  return (
    <div className="container">
      {showCourses && <CourseDetails />}
      {showBooks ? <BookDetails /> : <p>No Books Available</p>}
      {(() => {
        let blogSection;
        if (showBlogs) {
          blogSection = <BlogDetails />;
        } else {
          blogSection = <p>No Blogs Available</p>;
        }
        return blogSection;
      })()}
    </div>
  );
}


export default App;
