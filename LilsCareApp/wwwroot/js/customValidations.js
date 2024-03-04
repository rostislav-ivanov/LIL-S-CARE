// <reference path="../jquery.validate.js" />
// <reference path="../jquery.validate.unobtrusive.js" />

$.validator.addMethod("mustbetrue", function (value, element, params) {
  return element.checked;
});

$.validator.unobtrusive.adapters.addBool("mustbetrue");
