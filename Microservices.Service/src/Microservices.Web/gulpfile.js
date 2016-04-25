/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");

var paths = {
    webroot: "./wwwroot/"
};

paths.viewmodels = "Scripts/**/*.js";

paths.minJs = paths.webroot + "js/**/*.min.js";

paths.concatJsDest = paths.webroot + "js/site.min.js";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("min:mvvm", function () {
    return gulp.src([paths.viewmodels], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("clean", ["clean:js"]);

gulp.task("min", ["min:mvvm"]);