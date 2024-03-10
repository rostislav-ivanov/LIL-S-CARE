// Change plus/minus sign on click for collapsible elements Ingredients and Nutritional Information
const toggleSigns = document.querySelectorAll(".toggle-sign");

for (let i = 0; i < toggleSigns.length; i++) {
    toggleSigns[i].addEventListener("click", function () {
        const x = toggleSigns[i].querySelector("span");
        if (toggleSigns[i].classList.contains("collapsed")) {
            x.textContent = "+";
        } else {
            x.textContent = "-";
        }
    });
}

// Add comment functionality
//const leaveComment = document.getElementById("leave-comment");
//const commentProduct = document.getElementById("comment-product");
//const cancelCommentButton = document.getElementById("cancel-comment");

//leaveComment.querySelector("button").addEventListener("click", function (event) {
//    leaveComment.style.display = "none";
//    commentProduct.style.display = "block";
//});
//cancelCommentButton.addEventListener("click", function (event) {
//    event.preventDefault(); // Prevent default form submission behavior
//    leaveComment.style.display = "block";
//    commentProduct.style.display = "none";
//});

// Add star rating functionality
//const starRating = document.getElementById("star-rating");
//const radioButtons = starRating.querySelectorAll('input[type="checkbox"]');

//radioButtons.forEach(function (radioButton) {
//    radioButton.addEventListener("change", function () {
//        const selectedRating = this.id.split("_")[1];
//        updateStarRating(selectedRating);
//    });
//});

//function updateStarRating(rating) {
//    const stars = starRating.querySelectorAll("label");
//    stars.forEach(function (star, index) {
//        if (index < rating) {
//            star.innerHTML = '<i class="fa-solid fa-star"></i>';
//        } else {
//            star.innerHTML = '<i class="fa-regular fa-star"></i>';
//        }
//    });
//    radioButtons.forEach(function (input, index) {
//        if (index < rating) {
//			input.checked = true;
//		} else {
//			input.checked = false;
//		}
//    });
//}

//// Add image preview functionality to file inputs
//const fileInputs = document.querySelectorAll('input[type="file"]');
//const fileLabels = document.querySelectorAll(".btn-image");

//fileInputs.forEach(function (input, index) {
//    input.addEventListener("change", function () {
//        const file = this.files[0];
//        const label = fileLabels[index];

//        if (file) {
//            const reader = new FileReader();
//            reader.onload = function () {
//                label.style.backgroundImage = `url('${reader.result}')`;
//            };
//            reader.readAsDataURL(file);
//            label.textContent = "-";
//        } else {
//            label.textContent = "+";
//            label.style.backgroundImage = "none";
//        }
//    });
//});
