function solve() {
  const sections = document.querySelectorAll('section');
  const results = document.querySelector('#results'); // Предполага се, че имаш UL за резултата
  const resultMessage = results.querySelector('h1');
  const correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let rightAnswersCount = 0;
  let currentSectionIndex = 0;

  // Добавяме event listener-и на всички секции
  for (const section of sections) {
    const answers = section.querySelectorAll('li');

    // Слушаме за клик върху отговор
    answers.forEach(answer => {
      answer.addEventListener('click', () => {
        const answerText = answer.textContent.trim();

        // Проверка дали отговорът е верен
        if (correctAnswers.includes(answerText)) {
          rightAnswersCount++;
        }

        // Скриваме текущата секция
        section.style.display = 'none';

        // Показваме следващата секция, ако има такава
        currentSectionIndex++;
        if (currentSectionIndex < sections.length) {
          sections[currentSectionIndex].style.display = 'block';
        } else {
          // Краен резултат
          results.style.display = 'block';
          if (rightAnswersCount === 3) {
            resultMessage.textContent = 'You are recognized as top JavaScript fan!';
          } else {
            resultMessage.textContent = `You have ${rightAnswersCount} right answers`;
          }
        }
      });
    });
  }

  // Показваме само първата секция в началото
  sections.forEach((section, index) => {
    section.style.display = index === 0 ? 'block' : 'none';
  });
}
