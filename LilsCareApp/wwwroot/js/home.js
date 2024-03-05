const isFideEffect = true; // set true for fade effect, set false for slide effect
const caroselTimeTransition = 150; // 1000 = 1s - set this line if you use slide effect
const caroselInterval = 7000; // 1000 = 1s - set carousel interval

// Init Bootstrap Carousel
const carouselSlide = document.querySelector("#demo");

//Replase slide effect with fade effect to carousel
if (isFideEffect) {
  carouselSlide.classList.add("carousel-fade");
} else {
  //if you use slide effect, set transition duration for carousel items
  carouselSlide.querySelectorAll(".carousel-item").forEach(function (item) {
    item.style.transitionDuration = caroselTimeTransition;
  });
}

// Handle Bootstrap Carousel slide event
carouselSlide.addEventListener("slid.bs.carousel", onChanges);

// Handle Bootstrap Carousel slide event
function onChanges() {
  let carouselItem = carouselSlide.querySelector(
    ".carousel-item.active .carousel-caption"
  );
  // Show caption text
  carouselItem.classList.add("show");
  // Wait for transition to end
  // Hide caption text
  setTimeout(function () {
    carouselItem.classList.remove("show");
  }, caroselInterval);
}

// Set interval for carousel
var carousel = new bootstrap.Carousel(carouselSlide);
carousel._config.defaultInterval = caroselInterval;


//Redirecting to a specific element on a page after form submission-- >
// Check if there's a query parameter for scrolling
var scrollToElement = '@ViewData["scrollToElement"]';
if (scrollToElement) {
    // Use JavaScript to scroll to the specified element
    var element = document.getElementById(scrollToElement);
    if (element) {
        element.scrollIntoView({ behavior: 'instant' });
    }
}       
