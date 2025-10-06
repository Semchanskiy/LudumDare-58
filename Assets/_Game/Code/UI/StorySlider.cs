using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class StorySlider : MonoBehaviour
{

	List<Image> slides = new();
	[SerializeField] float fadeDuration = 0.5f;
	int currentIndex = 0;
	bool isClickLocked = false;

	[SerializeField] GameObject slide1;
	[SerializeField] GameObject slide2;
	[SerializeField] GameObject slide3;
	[SerializeField] GameObject slide4;

	void Start()
	{
		slides.Add(slide1.GetComponent<Image>());
		slides.Add(slide2.GetComponent<Image>());
		slides.Add(slide3.GetComponent<Image>());
		slides.Add(slide4.GetComponent<Image>());
		StartCoroutine(PlayNextSlide());
	}

	public void NextSlide()
	{
		if (isClickLocked)
		{
			return;
		}

		if (currentIndex >= slides.Count)
		{
			StartCoroutine(HideSlides());
		}
		else
		{
			StartCoroutine(PlayNextSlide());
		}
	}

	private IEnumerator PlayNextSlide()
	{
		isClickLocked = true;
		Image slide = slides[currentIndex];
		float elapsed = 0f;
		while (elapsed < fadeDuration)
		{
			elapsed += Time.deltaTime;
			float t = elapsed / fadeDuration;
			slide.color = new Color(1, 1, 1, t);
			yield return null;
		}
		currentIndex++;
		isClickLocked = false;
	}

	private IEnumerator HideSlides()
	{
		isClickLocked = true;
		Image lastSlide = slides[slides.Count - 1];
		for (int i = 0; i < slides.Count - 1; i++)
		{
			Destroy(slides[i].gameObject);
		}
		Destroy(lastSlide.transform.parent.GetComponent<Image>());

		G.run.StartGame();

		float elapsed = 0f;
		while (elapsed < fadeDuration)
		{
			elapsed += Time.deltaTime;
			float t = elapsed / fadeDuration;
			lastSlide.color = new Color(1, 1, 1, 1f - t);
			yield return null;
		}
		Destroy(gameObject);
	}

}