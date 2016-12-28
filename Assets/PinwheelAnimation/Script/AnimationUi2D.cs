using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AnimationUi2D : MonoBehaviour
{
    public Zoom2dParam zoomIn;
    public Zoom2dParam zoomOut;
    public FadeParam fadeIn;
    public FadeParam fadeOut;

    public AnimationCurve[] additionalCurves;

    RectTransform rectTransform;
    Graphic[] g;
    public Vector3 initScale;
    SpriteRenderer[] spriteRenderer;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        g = GetComponentsInChildren<Graphic>();
        initScale = transform.localScale;
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
    }

    public AnimationUi2D ZoomIn2d()
    {
        StartCoroutine(zoomIn2d());
        return this;
    }

    public IEnumerator zoomIn2d()
    {
        if (zoomIn.deactivateUI && g.Length != 0)
        {
            foreach (Graphic gi in g)
            {
                gi.raycastTarget = false;
            }
        }

        float time = 0;
        float scaleX, scaleY;
        while (time < zoomIn.duration)
        {
            scaleX = zoomIn.xCurve.Evaluate(time / zoomIn.duration);
            scaleY = zoomIn.yCurve.Evaluate(time / zoomIn.duration);
            transform.localScale = new Vector3(scaleX * initScale.x, scaleY * initScale.y, 1);
            time += Time.deltaTime;
            yield return null;
        }

        scaleX = zoomIn.xCurve.Evaluate(1);
        scaleY = zoomIn.yCurve.Evaluate(1);
        transform.localScale = new Vector3(scaleX * initScale.x, scaleY * initScale.y, 1);

        if (zoomIn.deactivateUI && g.Length != 0)
        {
            foreach (Graphic gi in g)
            {
                gi.raycastTarget = true;
            }
        }
    }

    public AnimationUi2D ZoomOut2d()
    {
        StartCoroutine(zoomOut2d());
        return this;
    }

    public IEnumerator zoomOut2d()
    {
        if (zoomIn.deactivateUI && g.Length != 0)
        {
            foreach (Graphic gi in g)
            {
                gi.raycastTarget = false;
            }
        }

        float time = 0;
        float scaleX, scaleY;
        while (time < zoomOut.duration)
        {
            scaleX = zoomOut.xCurve.Evaluate(time / zoomOut.duration);
            scaleY = zoomOut.yCurve.Evaluate(time / zoomOut.duration);
            transform.localScale = new Vector3(scaleX * initScale.x, scaleY * initScale.y, 1);
            time += Time.deltaTime;
            yield return null;
        }

        scaleX = zoomOut.xCurve.Evaluate(1);
        scaleY = zoomOut.yCurve.Evaluate(1);
        transform.localScale = new Vector3(scaleX * initScale.x, scaleY * initScale.y, 1);

        if (zoomOut.deactivateUI && g.Length != 0)
        {
            foreach (Graphic gi in g)
            {
                gi.raycastTarget = true;
            }
        }
    }

    public AnimationUi2D FadeIn()
    {
        print("fade in");
        if (fadeIn.type == FadeType.Sprite)
            StartCoroutine(fadeInSprite());
        else
            StartCoroutine(fadeInUi());
        return this;
    }

    public IEnumerator fadeInSprite()
    {
        float time = 0;
        float alpha;
        while (time <= fadeIn.duration)
        {
            alpha = fadeIn.curve.Evaluate(time / fadeIn.duration);
            for (int i = 0; i < (!fadeIn.fadeChildren ? 1 : spriteRenderer.Length); ++i)
            {
                spriteRenderer[i].color = new Color(spriteRenderer[i].color.r, spriteRenderer[i].color.g, spriteRenderer[i].color.b, alpha);
                time += Time.deltaTime;
                yield return null;
            }
        }
        alpha = fadeIn.curve.Evaluate(1);
        for (int i = 0; i < (!fadeIn.fadeChildren ? 1 : spriteRenderer.Length); ++i)
        {
            spriteRenderer[i].color = new Color(spriteRenderer[i].color.r, spriteRenderer[i].color.g, spriteRenderer[i].color.b, alpha);
        }

    }

    public IEnumerator fadeInUi()
    {
        if (fadeIn.deactivateUI)
        {
            foreach (Graphic gi in g)
            {
                gi.raycastTarget = false;
            }
        }

        float time = 0;
        float alpha;
        while (time <= fadeIn.duration)
        {
            alpha = fadeIn.curve.Evaluate(time / fadeIn.duration);
            for (int i = 0; i < (!fadeIn.fadeChildren ? 1 : g.Length); ++i)
            {
                g[i].color = new Color(g[i].color.r, g[i].color.g, g[i].color.b, alpha);
                time += Time.deltaTime;
                yield return null;
            }
        }
        alpha = fadeIn.curve.Evaluate(1);
        for (int i = 0; i < (!fadeIn.fadeChildren ? 1 : g.Length); ++i)
        {
            g[i].color = new Color(g[i].color.r, g[i].color.g, g[i].color.b, alpha);
        }

        if (fadeIn.deactivateUI)
        {
            foreach (Graphic gi in g)
            {
                gi.raycastTarget = true;
            }
        }
    }

    public AnimationUi2D FadeOut()
    {
        if (fadeOut.type == FadeType.Sprite)
            StartCoroutine(fadeOutSprite());
        else
            StartCoroutine(fadeOutUi());
        return this;
    }

    public IEnumerator fadeOutSprite()
    {
        float time = 0;
        float alpha;
        while (time <= fadeOut.duration)
        {
            alpha = fadeOut.curve.Evaluate(time / fadeOut.duration);
            for (int i = 0; i < (!fadeOut.fadeChildren ? 1 : spriteRenderer.Length); ++i)
            {
                spriteRenderer[i].color = new Color(spriteRenderer[i].color.r, spriteRenderer[i].color.g, spriteRenderer[i].color.b, alpha);
                time += Time.deltaTime;
                yield return null;
            }
        }
        alpha = fadeOut.curve.Evaluate(1);
        for (int i = 0; i < (!fadeOut.fadeChildren ? 1 : spriteRenderer.Length); ++i)
        {
            spriteRenderer[i].color = new Color(spriteRenderer[i].color.r, spriteRenderer[i].color.g, spriteRenderer[i].color.b, alpha);
        }

    }

    public IEnumerator fadeOutUi()
    {
        if (fadeOut.deactivateUI)
        {
            foreach (Graphic gi in g)
            {
                gi.raycastTarget = false;
            }
        }

        float time = 0;
        float alpha;
        while (time <= fadeOut.duration)
        {
            alpha = fadeOut.curve.Evaluate(time / fadeOut.duration);
            for (int i = 0; i < (!fadeOut.fadeChildren ? 1 : g.Length); ++i)
            {
                g[i].color = new Color(g[i].color.r, g[i].color.g, g[i].color.b, alpha);
                time += Time.deltaTime;
                yield return null;
            }
        }
        alpha = fadeOut.curve.Evaluate(1);
        for (int i = 0; i < (!fadeOut.fadeChildren ? 1 : g.Length); ++i)
        {
            g[i].color = new Color(g[i].color.r, g[i].color.g, g[i].color.b, alpha);
        }

        if (fadeOut.deactivateUI)
        {
            foreach (Graphic gi in g)
            {
                gi.raycastTarget = true;
            }
        }
    }

    public AnimationUi2D Scale(AnimationCurve curve, float duration)
    {
        StartCoroutine(scale(curve, duration));
        return this;
    }

    public IEnumerator scale(AnimationCurve curve, float duration)
    {
        float time = 0;
        float scaleX, scaleY;
        while (time < duration)
        {
            scaleX = curve.Evaluate(time / duration);
            scaleY = curve.Evaluate(time / duration);
            transform.localScale = new Vector3(scaleX * initScale.x, scaleY * initScale.y, 1);
            time += Time.deltaTime;
            yield return null;
        }

        scaleX = curve.Evaluate(1);
        scaleY = curve.Evaluate(1);
        transform.localScale = new Vector3(scaleX * initScale.x, scaleY * initScale.y, 1);

    }
}
