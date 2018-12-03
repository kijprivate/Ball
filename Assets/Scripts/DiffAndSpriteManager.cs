using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffAndSpriteManager : MonoBehaviour {

    [SerializeField] Chunk[] chunks;
    [SerializeField] GameObject[] backgrounds;
    [SerializeField] Sprite[] barSprites;
    [SerializeField] Sprite[] gemSprites;

    private enum States { u25,o25u50,o50u75,o75u100,o100u125,o125u150,o150u175,o175u200,o200u225,o225u250,o250};
    private States myState;
    Ball ball;

    void Start ()
    {
        ball = FindObjectOfType<Ball>();
        myState = States.u25;

        Gem.gemValue = 1;
        Bar.barSpeed = 2f;

        ChangeSpritesGems(0);
        SetStartingSprites();
    }

    // Update is called once per frame
    void Update () {
        if (ball.distance > 25f && myState == States.u25)
        {
            ChangeBarSpeed(1);
            ChangeSpritesBars(1);
            myState = States.o25u50; 
        }

        if (ball.distance > 50f && myState == States.o25u50)
        {
            ChangeBarSpeed(2);
            ChangeSpritesBars(2);

            ChangeSpritesGems(1);
            ChangeGemValue(2);

            myState = States.o50u75;
        }

        if (ball.distance > 75f && myState == States.o50u75)
        {
            ChangeBarSpeed(3);
            ChangeSpritesBars(3);
            myState = States.o75u100;
        }

        if (ball.distance > 100f && myState == States.o75u100)
        {
            ChangeBarSpeed(4);
            ChangeSpritesBars(4);

            ChangeSpritesGems(2);
            ChangeGemValue(3);

            myState = States.o100u125;
        }

        if (ball.distance > 125f && myState == States.o100u125)
        {
            ChangeBarSpeed(5);
            ChangeSpritesBars(5);
            myState = States.o125u150;
        }

        if (ball.distance > 150f && myState == States.o125u150)
        {
            ChangeBarSpeed(6);
            ChangeSpritesBars(6);

            ChangeSpritesGems(3);
            ChangeGemValue(4);

            myState = States.o150u175;
        }

        if (ball.distance > 175f && myState == States.o150u175)
        {
            ChangeBarSpeed(7);
            ChangeSpritesBars(7);
            myState = States.o175u200;
        }

        if (ball.distance > 200f && myState == States.o175u200)
        {
            ChangeBarSpeed(8);
            ChangeSpritesBars(8);

            ChangeSpritesGems(4);
            ChangeGemValue(5);

            myState = States.o200u225;
        }

        if (ball.distance > 225f && myState == States.o200u225)
        {
            ChangeBarSpeed(9);
            ChangeSpritesBars(9);
            myState = States.o225u250;
        }

        if (ball.distance > 250f && myState == States.o225u250)
        {
            ChangeBarSpeed(10);
            ChangeSpritesBars(10);

            ChangeSpritesGems(5);
            ChangeGemValue(6);

            myState = States.o250;
        }

    }

    void ChangeBarSpeed(int duplicator)
    {
        Bar.barSpeed = 2f + 0.1f * duplicator;
    }

    void ChangeGemValue(int duplicator)
    {
        Gem.gemValue = 1*duplicator ;
    }

    void ChangeSpritesBars(int duplicator)
    {
        foreach (Chunk chunk in chunks)
        {
            Bar[] bars = chunk.GetComponentsInChildren<Bar>();
            foreach (Bar bar in bars)
            {
                Bar[] existBar = FindObjectsOfType<Bar>();
                foreach (Bar barExist in existBar)
                {
                    SpriteRenderer[] spritesExistBar = barExist.GetComponentsInChildren<SpriteRenderer>();
                    foreach (SpriteRenderer sprite in spritesExistBar)
                    {
                        sprite.sprite = barSprites[duplicator];
                    }
                }
                SpriteRenderer[] sprites = bar.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer sprite in sprites)
                {
                    sprite.sprite = barSprites[duplicator];
                }
            }
        }
        
        Instantiate(backgrounds[duplicator]);
        Destroy(GameObject.FindGameObjectWithTag("Background"));
    }

    void ChangeSpritesGems(int duplicator)
    {
        foreach (Chunk chunk in chunks)
        {
            Gem[] gems = chunk.GetComponentsInChildren<Gem>();
            foreach (Gem gem in gems)
            {
                Gem[] existGem = FindObjectsOfType<Gem>();
                foreach (Gem gemExist in existGem)
                {
                    SpriteRenderer[] spritesExistGem = gemExist.GetComponentsInChildren<SpriteRenderer>();
                    foreach (SpriteRenderer sprite in spritesExistGem)
                    {
                        sprite.sprite = gemSprites[duplicator];
                    }
                }
                SpriteRenderer[] sprites = gem.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer sprite in sprites)
                {
                    sprite.sprite = gemSprites[duplicator];
                }
            }
        }
    }

    private void SetStartingSprites()
    {
        foreach (Chunk chunk in chunks)
        {
            Bar[] bars = chunk.GetComponentsInChildren<Bar>();
            foreach (Bar bar in bars)
            {
                SpriteRenderer[] sprites = bar.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer sprite in sprites)
                {
                    sprite.sprite = barSprites[0];
                }
            }
        }

        foreach (GameObject background in backgrounds)
        {
            SpriteRenderer sprite = background.GetComponent<SpriteRenderer>();
            sprite.color = new Color(1, 1, 1, 1);
        }
    }
}
