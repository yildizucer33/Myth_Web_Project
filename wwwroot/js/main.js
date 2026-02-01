
 

    // Yeni butonlar için özellik ekle (örnek amaçlı log ve alert)
    const buttons = document.querySelectorAll('.btn');
    buttons.forEach(function (button) {
      button.addEventListener('click', function () {
        console.log(`Button clicked: ${this.textContent.trim()}`);
        // alert(`You clicked on: ${this.textContent.trim()}`);
      });
    });

    // "Devamı" butonları için işlev
    function toggleStory(id) {
      const dots = document.getElementById("dots" + id);
      const fullText = document.getElementById("fullText" + id);
      const button = document.getElementById("more" + id);
      
      if (fullText && dots && button) {
        button.addEventListener("click", function () {
          const isHidden = fullText.style.display === "none";
          fullText.style.display = isHidden ? "block" : "none";
          dots.style.display = isHidden ? "none" : "inline";
          button.textContent = isHidden ? "Gizle" : "Devamı";
        });
      }
    }
  

    // ID’leri tanımlı tüm hikayeler için devamı butonlarına gerekli olan fonksiyon
    
    [1, 2, 3, 4, 5, 6].forEach(toggleStory);
  