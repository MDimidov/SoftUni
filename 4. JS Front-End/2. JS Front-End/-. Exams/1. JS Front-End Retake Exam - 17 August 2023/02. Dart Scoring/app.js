window.addEventListener("load", solve);

function solve() {
  const inputs = Array.from(document.querySelectorAll('.scoring-content input'));
  const inputPlayerName = inputs[0];
  const inputScore = inputs[1];
  const inputRound = inputs[2]
  const sureListUl = document.querySelector('#sure-list');
  const scoreBoardUl = document.querySelector('#scoreboard-list');
  const btnClear = document.querySelector('.btn.clear')

  const addBtn = document.querySelector('#add-btn');


  addBtn.addEventListener('click', addInformation);
  btnClear.addEventListener('click', () => {
    location.reload();
  })

  function addInformation(e) {
    for (const input of inputs) {
      if (input.value === "") {
        return;
      }
    }

    const playerName = inputPlayerName.value;
    const score = Number(inputScore.value);
    const round = Number(inputRound.value);
    addInformationChild(playerName, score, round);

    e.target.disabled = true;

    for (const input of inputs) {
      input.value = "";
    }
  }

  function addInformationChild(playerName, score, round) {
    const pPlayerName = document.createElement('p');
    pPlayerName.textContent = playerName;
    const pScore = document.createElement('p');
    pScore.textContent = `Score: ${score}`;
    const pRound = document.createElement('p');
    pRound.textContent = `Round: ${round}`;

    const articleChild = document.createElement('article');
    articleChild.appendChild(pPlayerName);
    articleChild.appendChild(pScore);
    articleChild.appendChild(pRound);

    const btnEdit = document.createElement('button');
    btnEdit.classList.add('btn', 'edit');
    btnEdit.textContent = 'edit';
    btnEdit.addEventListener('click', editInfo);

    const btnOk = document.createElement('button');
    btnOk.classList.add('btn', 'ok');
    btnOk.textContent = 'ok';
    btnOk.addEventListener('click', addToScoreBoard);

    const liChild = document.createElement('li');
    liChild.classList.add('dart-item');
    liChild.appendChild(articleChild);
    liChild.appendChild(btnEdit);
    liChild.appendChild(btnOk);

    sureListUl.appendChild(liChild);

  }

  function editInfo(e) {
    const liChild = e.target.parentElement;
    const pElements = Array.from(liChild.querySelectorAll('article p'));
    inputPlayerName.value = pElements[0].textContent;
    inputScore.value = pElements[1].textContent.split('Score: ')[1];
    inputRound.value = pElements[2].textContent.split('Round: ')[1];

    addBtn.disabled = false;

    sureListUl.removeChild(liChild);
  }

  function addToScoreBoard(e) {
    const liChild = e.target.parentElement;
    const btnEdit = liChild.querySelector('.btn.edit');
    const btnOk = liChild.querySelector('.btn.ok');

    const btnClear = document.createElement('button');
    btnClear.classList.add('btn', 'clear');
    btnClear.textContent = 'Clear';
    btnClear.addEventListener('click', editInfo);

    liChild.removeChild(btnEdit);
    liChild.removeChild(btnOk);

    sureListUl.removeChild(liChild);
    scoreBoardUl.appendChild(liChild);

    addBtn.disabled = false;
  }
}
