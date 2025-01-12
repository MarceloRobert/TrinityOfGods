using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrinityOfGods.Content.Projectiles
{
	public class ExampleCardProjectile : ModProjectile
	{
		// public override void SetStaticDefaults() {
		// 	ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
		// 	ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
		// }

		public override void SetDefaults() {
			Projectile.width = 16; // The width of projectile hitbox
			Projectile.height = 16; // The height of projectile hitbox
			Projectile.aiStyle = 2; // The ai style of the projectile, reference https://docs.google.com/spreadsheets/d/1aYgpXehVahT669zxg4B3C2nfxoF8P9mK_clvjgwCTSU/edit?gid=1690991103#gid=1690991103
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
			Projectile.penetrate = 5; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.tileCollide = true; // Can the projectile collide with tiles?
			Projectile.extraUpdates = 1; // Set to above 0 if you want the projectile to update multiple time in a frame

			AIType = ProjectileID.ThrowingKnife;
		}

		// public override bool OnTileCollide(Vector2 oldVelocity) {
		// 	// If collide with tile, reduce the penetrate.
		// 	// So the projectile can reflect at most 5 times
		// 	Projectile.penetrate--;
		// 	if (Projectile.penetrate <= 0) {
		// 		Projectile.Kill();
		// 	}
		// 	else {
		// 		Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
		// 		SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

		// 		// If the projectile hits the left or right side of the tile, reverse the X velocity
		// 		if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon) {
		// 			Projectile.velocity.X = -oldVelocity.X;
		// 		}

		// 		// If the projectile hits the top or bottom side of the tile, reverse the Y velocity
		// 		if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon) {
		// 			Projectile.velocity.Y = -oldVelocity.Y;
		// 		}
		// 	}

		// 	return false;
		// }

		public override void OnKill(int timeLeft) {
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}