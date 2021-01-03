using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace TynyransMod
{
  public class Tynyran : ModPlayer
  {
    public bool deflectable,
                micitBangle,
                micitEarrings1,
                micitEarrings2;
    public float tynyran;
    public int tynyranCrit;

    public override void ResetEffects()
    {
      deflectable = false;
      micitBangle = false;
      micitEarrings1 = false;
      micitEarrings2 = false;
      tynyran = 1f;
      tynyranCrit = 0;
    }

    public override void ModifyManaCost(Item item, ref float reduce, ref float mult)
    {
      if (micitEarrings1 && micitEarrings2)
        reduce -= 0.35f;
    }
  }
}