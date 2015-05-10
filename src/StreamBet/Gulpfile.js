/// <binding BeforeBuild='buildts' Clean='clean' ProjectOpened='tsd, copy' />

/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require("gulp");
var del = require("del");
var fs = require("fs");
var tsc = require("gulp-tsc");
var tsd = require("gulp-tsd");

eval("var project = " + fs.readFileSync("./project.json"));

var paths = {
    bower: "./bower_components/",
    lib: "./" + project.webroot + "/lib/",
    js: "./" + project.webroot + "/js/",
    ts: "./" + project.webroot + "/ts/",
    tscripts: ["./Scripts/**/*.ts"]
};

gulp.task("clean", function (cb) {
    del([paths.lib, paths.js], cb);
});

gulp.task("copy", ["clean"], function () {
    var bower = {
        "bootstrap": "bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,eot}",
        "jquery": "jquery/dist/jquery*.{js,map}",
        "jquery-ujs": "jquery-ujs/src/rails.js",
        "jquery-validation": "jquery-validation/dist/jquery.validate.js",
        "jquery-validation-unobtrusive": "jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"
    }

    for (var destinationDir in bower) {
        gulp.src(paths.bower + bower[destinationDir])
          .pipe(gulp.dest(paths.lib + destinationDir));
    }
});

gulp.task("buildts", function () {
    gulp.src(paths.tscripts)
        .pipe(tsc({
            module: "amd",
            target: "es5",
            out: "app.js",
            sourcemap: true,
            emitError: false
        }))
        .pipe(gulp.dest(paths.js));
});

gulp.task("tsd", function (cb) {
    tsd({ command: "reinstall", config: "./tsd.json" }, cb);
});