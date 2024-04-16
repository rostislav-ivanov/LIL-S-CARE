const isFideEffect = true; // set true for fade effect, set false for slide effect
const caroselTimeTransition = 150; // 1000 = 1s - set this line if you use slide effect
const caroselInterval = 2500; // 1000 = 1s - set carousel interval

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
