using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace TynyransMod.Projectiles
{
  public class ProjectorShield : ModProjectile
  {
    private const float radius = 100f;
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Projector Shield");
    }

    public override void SetDefaults()
    {
      projectile.friendly = true;
      projectile.width = 30;
      projectile.height = 28;
      projectile.aiStyle = 0;
      projectile.tileCollide = true;
      projectile.ignoreWater = true;
      projectile.timeLeft = 300;
      projectile.scale = 1f;
      projectile.damage = 300;
    }
    private void CreateShieldField()
    {
      for (float rotation = 0f; rotation < 360f; rotation += 45f)
      {
        Vector2 spawnPosition = projectile.Center + new Vector2(0f, radius).RotatedBy(rotation.InRadians());
        Dust d = Dust.NewDustPerfect(spawnPosition, 16, null, 90, new Color(255, 255, 255), 1f);
        d.noLight = true;
        d.noGravity = true;
      }
    }
    public override void AI()
    {
      CreateShieldField();
      foreach (Projectile proj in Main.projectile)
      {
        if (proj.active && proj.hostile && proj.position.IsInRadius(projectile.position, radius))
        {
          for (int i = 0; i < 5; i++)
            _ = Dust.NewDust(proj.position, 3, 3, 16, 0, 0, 90, new Color(255,255,255), 1f);
          proj.Kill();
          proj.active = false;
        }
      }
    }

    public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
    {
      return false;
    }
  }
}