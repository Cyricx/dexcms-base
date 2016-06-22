/// <binding BeforeBuild='clean' AfterBuild='copy' />
module.exports = function (grunt) {
    //Configuration setup
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        copy: {
            domain: {
                expand: true,
                cwd: 'DexCMS.Base/bin/Release/',
                src: ['DexCMS.Base.dll'],
                dest: 'dist/'
            },
            mvc: {
                expand: true,
                cwd: 'DexCMS.Base.Mvc/bin/Release/',
                src: ['DexCMS.Base.Mvc.dll'],
                dest: 'dist/'
            },
            webapi: {
                expand: true,
                cwd: 'DexCMS.Base.WebApi/bin/Release/',
                src: ['DexCMS.Base.WebApi.dll'],
                dest: 'dist/'
            }
        },
        clean: {
            build: ["dist"]
        }
    });

    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-clean');

    grunt.registerTask('default', ['clean', 'copy']);
};
