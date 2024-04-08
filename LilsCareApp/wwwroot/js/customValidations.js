/// <reference path="../lib/jquery-validation/dist/jquery.validate.js" />
/// <reference path="../lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js" />

$.validator.addMethod("mustbetrue", function (value, element, params) {
	return element.checked;
});

$.validator.unobtrusive.adapters.addBool("mustbetrue");

