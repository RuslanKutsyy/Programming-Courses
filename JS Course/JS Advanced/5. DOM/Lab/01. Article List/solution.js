function createArticle() {
	let title = document.getElementById('createTitle').value;
	let content = document.getElementById('createContent').value;
	let articlesContent = document.getElementById('articles');

	if (title !== '' && content !== '') {
		let article = document.createElement('article');

		let header = document.createElement('h3');
		let headerData = document.createTextNode(title);
		header.appendChild(headerData);
		article.appendChild(header);

		let paragraph = document.createElement('p');
		let paragraphData = document.createTextNode(content);
		paragraph.appendChild(paragraphData);
		article.appendChild(paragraph);

		articlesContent.appendChild(article);
	}

	document.getElementById('createTitle').value = null;
	document.getElementById('createContent').value = null;
}