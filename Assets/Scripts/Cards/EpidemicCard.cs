﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EpidemicCard : PlayerCard {
    private static EpidemicCard INSTANCE = new EpidemicCard();

    private EpidemicCard() : base(CardType.EpidemicCard)
    {
    }
    
    public static EpidemicCard getEpidemicCard()
    {
        return INSTANCE;
    }
}
