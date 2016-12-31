# DexCMS.Base

## You have just stumbled upon a superbly early version of a .Net CMS, right now it is an 
aggregation of shared code across several small websites. Soon it will be awesome, right now, it's in progress. :)

## DexCMS.Base Development Rules
* This library is for code specific to the Alerts domain
* It contains 3 libraries:
	* DexCMS.Base
		* For code not specific to mvc, webapi, etc.
	* DexCMS.Base.Mvc
		* For code specific to MVC sites
	* DexCMS.Base.WebApi
		* For code specific to WebApi sites
* These libraries can depend on Core libraries only.
* Before submitting a pull request, be sure you have installed the node packages and build the project in Release.
    * This includes the compiled dll into a /dist/ folder that consuming applications can use if I cut a new version off of your pull request.

## 0.5.0-alpha
* Another version ready to go

## 0.4.0-alpha
* Reworked initializers

## 0.3.1-alpha
* Client
	* Fixed images.service.js incorrect function definition

## 0.3.0-alpha
* Many improvements and bug fixes (yay alpha versions!)

## 0.2.0 (alpha)
* Changed references to TTCMS to DexCMS

## 0.1.0 (alpha)
* Initial Build

### CREDITS
* Ben Foster (Fabrik) for the sitemap generator that has been implemented in this library
    * https://github.com/benfoster/Fabrik.Common/tree/master/src/Fabrik.Common.Web/SEO